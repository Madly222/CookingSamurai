using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookEffect : MonoBehaviour
{
    //[SerializeField] private LevelManager levelManager;
    [SerializeField] private EffectHolder effectHolder;

    private GameObject _effect;
    private int _id;

    private void Start()
    {
        ChangeEffect(0);
    }

    public void ChangeEffect(int  index)
    {
        _id = index;
        DeleteEffects();
        TakeEffect();
    }
    private void TakeEffect()
    {
        if (_id >= effectHolder.cooking.Length || _id < 0)
        {
            _id = 0;
            Logger.LogError("Effect index out of holder", gameObject);
        }
            
        _effect = Instantiate(effectHolder.GetCookingEffect(_id), transform, true);
        _effect.transform.localPosition = Vector3.zero;
        _effect.transform.localRotation  = Quaternion.Euler(0, 0, 0);
    }
    
    private void DeleteEffects()
    {
        if (transform.childCount <= 0) return;
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
