using System.Collections.Generic;
using UnityEngine;

public class CookPool : MonoBehaviour
{
    [System.Serializable]
    public class RandomVariation
    {
        public string ingredientName;
        public Sprite image;
    }
    
    [System.Serializable]
    public class AllIngredients
    {
        public GameObject toSlice;
    }
    
    [System.Serializable]
    public class RecipeVariation
    {
        public int coinReward;
        public GameObject fullPrepared;
        
        public RandomVariation[] recipe;
    }
    
    [System.Serializable]
    public class FoodRecipe
    {
        public string recipeName;
        public string boardType;
        public Sprite npcUI;
        public AllIngredients[] ingredients;

        public RecipeVariation[] variations;
    }

    public FoodRecipe[] recipes;
    
    [SerializeField] public List<GameObject> nonPreparable = new ();
    [SerializeField] public List<GameObject> trashPrepared = new ();
}
