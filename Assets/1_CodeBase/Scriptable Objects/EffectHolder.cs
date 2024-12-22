using UnityEngine;
[CreateAssetMenu(fileName = "EffectHolder", menuName = "ScriptableObjects/EffectHolder", order = 1)]
public class EffectHolder : ScriptableObject
{
    public GameObject[] slide;
    public GameObject[] multiSlide;
    public GameObject[] cooking;
    public GameObject GetSlideEffect(int index)
    {
        if (index >= 0 && index < slide.Length)
        {
            return slide[index];
        }
        
        Debug.LogWarning("Inexistent slide effect");
        return null;
    }
    
    public GameObject GetMultiSlideEffect(int index)
    {
        if (index >= 0 && index < multiSlide.Length)
        {
            return multiSlide[index];
        }
        
        Debug.LogWarning("Inexistent multi slice effect");
        return null;
    }
    
    public GameObject GetCookingEffect(int index)
    {
        if (index >= 0 && index < cooking.Length)
        {
            return cooking[index];
        }
        
        Debug.LogWarning("Inexistent cooking effect");
        return null;
    }
}
