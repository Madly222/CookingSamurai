using UnityEngine;

[CreateAssetMenu(fileName = "CookedFood", menuName = "ScriptableObjects/CookedFood", order = 2)]
public class CookedFood : ScriptableObject
{
    [System.Serializable]
    public class RecipeIngredient
    {
        public string name;
        public GameObject toSlice;
        public GameObject prepared;
    }
    
    [System.Serializable]
    public class FoodRecipe
    {
        public string foodName;
        public RecipeIngredient[] ingredients;
    }

    public FoodRecipe[] recipes;
}
