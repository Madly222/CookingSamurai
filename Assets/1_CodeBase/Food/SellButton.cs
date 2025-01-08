using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{

    [SerializeField] private LevelManager levelManager;
    [SerializeField] private CookController cookController;
    [SerializeField] private AnimationController animationController;
        
    [SerializeField] private CoinUI coinUI;
    
    [SerializeField] private AudioClip sellSound;
    
    private int _points;
    
    public void OnMouseDown()
    {
        //Check can play animation for sale and if yes - sell it
        if(animationController.PlaySellAnimation())
            return;
        
        coinUI.CoinIncrease(levelManager.IncreaseGold(_points),_points);
        cookController.ChangeFood();
        
        SoundPlayer.Instance.PlayEffect(sellSound, transform);
        gameObject.SetActive(false);
    }

    public void SetPrice(int price)
    {
        _points = price;
    }
}
