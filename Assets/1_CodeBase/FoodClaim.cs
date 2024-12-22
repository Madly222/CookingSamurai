using UnityEngine;

public class FoodClaim : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    private FoodData _foodData;
    private ItemReloader _itemReloader;
    private void OnTriggerEnter(Collider other)
    {
        _foodData = other.GetComponent<FoodData>();
        if(_foodData)
            _foodData.ClaimItem();
        
        _itemReloader = other.GetComponent<ItemReloader>();
        if(_itemReloader)
            _itemReloader.ResetItem();
    }
}
