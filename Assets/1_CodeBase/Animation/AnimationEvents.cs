using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private CookController cookController;

    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;

    private bool _temp;
    
    public void StopCook(int canClaim)
    {
        _temp = canClaim == 0;
        cookController.CanClaimChange(_temp);
    }

    public void ButtonSwitcher(int grades)
    {
        _temp = grades == 180;
        buttonLeft.SetActive(_temp);
        buttonRight.SetActive(!_temp);
    }
    
    public void SellItem()
    {
        cookController.SellFood();
    }
}
