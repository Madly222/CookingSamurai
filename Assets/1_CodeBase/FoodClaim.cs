using UnityEngine;

public class FoodClaim : MonoBehaviour
{
    [SerializeField] private CookController cookController;
    private FoodData _foodData;
    private ParentReloader _parentReloader;
    private void OnTriggerEnter(Collider other)
    {
        _foodData = other.GetComponent<FoodData>();
        if(_foodData)
            _foodData.ClaimItem();
        
        _parentReloader = other.GetComponent<ParentReloader>();
        if(_parentReloader)
            _parentReloader.ResetItem();
    }
}
