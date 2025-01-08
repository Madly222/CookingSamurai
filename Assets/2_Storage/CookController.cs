using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CookController : MonoBehaviour
{
    [SerializeField] private CookPool cookPool;
    [SerializeField] private ItemDropper itemDropper;
    [SerializeField] private NpcUiController npcUiController;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private SellButton sellButton;
    
    [SerializeField] private int recipeLevel = 1;
    
    [SerializeField] private List<GameObject> boardPoint;
    [SerializeField] private List<CookPool.RandomVariation> foodImage;
    
    [SerializeField] public string boardType = "standart";
    
    private int _nrPrepared;
    private int _randomRecipe;
    private int _playerScore;
    private int _randomVariation;
    private int _currentItem = -1;
    private readonly List<string> _claimed = new();
    
    private bool _canClaim = true;
    //[SerializeField] private AudioSource soundSource;
    //[SerializeField] private AudioClip soundEffect; 
    
    private Transform _tempTransform;
    
    public void Start() 
    {
        ChangeFood();
        itemDropper.trash = cookPool.nonPreparable;
    }

    public void ChangeFood()
    {
        npcUiController.DisableBoxes();
        _randomRecipe = Randomizer(0, recipeLevel);
        _randomVariation = Randomizer(0, cookPool.recipes[_randomRecipe].variations.Length);

        itemDropper.goodFood = cookPool.recipes[_randomRecipe].ingredients.Select(i => i.toSlice).ToList();

        npcUiController.ChangeDialogBox(cookPool.recipes[_randomRecipe].npcUI);
        
        for (var k = 0; k < cookPool.recipes[_randomRecipe].variations[_randomVariation].recipe.Length; k++)
            npcUiController.ChangeTextureItem(k, cookPool.recipes[_randomRecipe].variations[_randomVariation].recipe[k].image);
    }
    public bool SpawnPreparedPiece(GameObject preparedFood, string claimedName)
    {
        if(!_canClaim)
            return _canClaim;
        
        MoveItem(preparedFood, boardPoint[_nrPrepared + 1]);
        
        CheckPreparing(claimedName);
        return _canClaim;
    }

    public void CheckPreparing(string foodName)
    {
        if (boardType != cookPool.recipes[_randomRecipe].boardType)
        {
            IncorrectBoard();
            return;
        }

        _currentItem = Array.FindIndex(cookPool.recipes[_randomRecipe].variations[_randomVariation].recipe,r => r.ingredientName.Contains(foodName));
        if (_currentItem == -1 || _claimed.Contains(foodName))
        {
            MakeBadFood();
            Logger.Log(_currentItem == -1 
                ? "Collected item is bad" 
                : "This item already taken", gameObject);
            return;
        }

        _claimed.Add(foodName);
        npcUiController.ChangeTextureColor(_currentItem);
        _nrPrepared++;

        if(_nrPrepared == cookPool.recipes[_randomRecipe].variations[_randomVariation].recipe.Length)
            MakeGoodFood();
    }

    private void IncorrectBoard()
    {
        Logger.Log("IncorrectBoard", gameObject);
    }
    private void MakeBadFood()
    {
        _canClaim = false;
        _nrPrepared = 0;
        npcUiController.RestartColors();
        _claimed.Clear();
        
        boardPoint[0].SetActive(false);
        animationController.PrepareFood(true);
        MoveItem(cookPool.trashPrepared[Randomizer(0, cookPool.trashPrepared.Count)], boardPoint[0]);
        
    }
    private void MakeGoodFood()
    {
        sellButton.SetPrice(cookPool.recipes[_randomRecipe].variations[_randomVariation].coinReward);
        
        
        _canClaim = false;
        _nrPrepared = 0;
        _claimed.Clear();
        
        boardPoint[0].SetActive(false);
        animationController.PrepareFood(false);
        MoveItem(cookPool.recipes[_randomRecipe].variations[_randomVariation].fullPrepared, boardPoint[0]);
    }

    private void MoveItem(GameObject item, GameObject point)
    {
        item.transform.SetParent(point.transform, false);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.SetActive(true);
        Logger.Log("Activated", item);
    }

    public void CanClaimChange(bool state)
    {
        _canClaim = state;
    }
    
    private IEnumerator TrashCooldown(int time)
    {
        yield return new WaitForSeconds(time);
        //_canClaim = true;
    }
    
    private static int Randomizer(int min, int max)
    {
        return Random.Range(min, max);;
    }
}
