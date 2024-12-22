using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private CoinUI coinUI;
    [SerializeField] private LevelManager levelManager;
    
    [SerializeField] private AudioClip sellSound;
    
    private int _points;
    
    public void OnMouseDown()
    {
        coinUI.CoinIncrease(_points, levelManager.IncreaseGold(_points));
        SoundPlayer.Instance.PlayEffect(sellSound, transform);
        gameObject.SetActive(false);
    }

    public void SetPrice(int price)
    {
        _points = price;
    }
}
