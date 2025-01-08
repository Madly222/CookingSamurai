using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    [SerializeField] private Updating updating;
    //[SerializeField] private SellButton sellButton;

    [SerializeField] private GameObject sellButton;
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;

    private bool _temp;
    
    public void DisableCook()
    {
        cookController.CanClaimChange(false);
        updating.canSlice = false;
    }
    
    public void EnableCook()
    {
        cookController.CanClaimChange(true);
        updating.canSlice = true;
    }

    public void DisableButtons()
    {
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        updating.canSlice = false;
    }
    public void ButtonSwitcher(string direction)
    {
        buttonLeft.SetActive(direction == "right");
        buttonRight.SetActive(direction == "left");
        updating.canSlice = direction == "right";
    }

    public void EnableSellButton()
    {
        sellButton.SetActive(true);
    }
    
    public void DisableSellButton()
    {
        sellButton.SetActive(false);
    }
}
