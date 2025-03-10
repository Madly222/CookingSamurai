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

    private void Awake()
    {
        CookController.OnChangeRecipe += SetPrice;
    }

    private void OnDestroy()
    {
        CookController.OnChangeRecipe -= SetPrice;
    }
    
    public void OnMouseDown()
    {
        coinUI.CoinIncrease(_points, levelManager.IncreaseGold(_points));
        SoundPlayer.Instance.PlayEffect(sellSound, transform);
        gameObject.SetActive(false);
        
        OnSell?.Invoke();
    }

    private void SetPrice(int price)
    {
        _points = price;
    }
}
