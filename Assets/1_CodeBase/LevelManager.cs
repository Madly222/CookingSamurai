using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _playerScore = 100;
    
    public int goodFoodChance = 10;
    public float maxSpawnSpeed = 1.5f;

    public int IncreaseGold(int points)
    {
        _playerScore += points;
        return _playerScore;
    }

    /*public int recipeUnlock = 1;

    public float maxSpawnSpeed = 1.5f;
    public float coinMultiplier = 1f;

    [SerializeField] public int slideEff;
    [SerializeField] private int multiSlideEff;
    [SerializeField] private int cookingEff;

    //[SerializeField] private EffectHolder effectHolder;

    public void UnlockRecipe()
    {
        recipeUnlock++;
    }

    public void GoodFoodChanceIncrease()
    {
        goodFoodChance++;
    }

    public void spawnSpeedIncrease()
    {
        maxSpawnSpeed -= 0.1f;
    }

    public void coinMultiplierIncrease()
    {
        coinMultiplier++;
    }*/
}
