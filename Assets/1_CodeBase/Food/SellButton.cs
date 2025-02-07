using System;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private CookController cookController;
    //[SerializeField] private AnimationController animationController;
        
    [SerializeField] private CoinUI coinUI;
    [SerializeField] private AudioClip sellSound;
    public static event Action OnSell;
    
    private int _points;
    
    private void OnEnable()
    {
         CookController.OnChangeRecipe += SetPrice;
    }

    private void OnDisable()
    {
        CookController.OnChangeRecipe -= SetPrice;
    }
    public void OnMouseDown()
    {
        coinUI.CoinIncrease(levelManager.IncreaseGold(_points),_points);
        //cookController.ChangeFood();
        SoundPlayer.Instance.PlayEffect(sellSound, transform);
        gameObject.SetActive(false);
        
        OnSell?.Invoke();
    }

    private void SetPrice(int price)
    {
        _points = price;
    }
}
