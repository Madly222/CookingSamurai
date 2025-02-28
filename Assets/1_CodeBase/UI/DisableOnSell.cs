using UnityEngine;

public class DisableOnSell : MonoBehaviour
{
    private void OnEnable()
    {
        SellButton.OnSell += DisableMe;
    }
    
    private void OnDisable()
    {
        SellButton.OnSell -= DisableMe;
    }

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
