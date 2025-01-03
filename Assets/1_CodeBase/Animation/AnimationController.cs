using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator sceneAnimator;
    
    private static readonly int PrepareID = Animator.StringToHash("PrepareID");
    private static readonly int IsTrash = Animator.StringToHash("IsTrash");

    private void Awake()
    {
       // cookEffect.transform.SetParent(effectPoint.transform);
        //cookEffect.transform.localPosition = Vector3.zero;
       // cookEffect.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        //cookEffect.SetActive(false);
    }

    public void OnButtonClick()
    {
        sceneAnimator.enabled = true;
    }
    
    public void PrepareFood(bool isTrash)
    {
        ChangeAnimatorState(true);
        sceneAnimator.Play(Randomizer(1, 2) == 1 ? "prepare1" : "prepare2");
        
        sceneAnimator.SetBool(IsTrash, isTrash);
    }
    
    public void DisableAnimator()
    {
        sceneAnimator.enabled = false;
    }

    public void PlaySellAnimation()
    {
        
    }
    
    public void RotateCamera(string animationName)
    {
        if (CheckAnimatorState())
        {
            Logger.Log("Wait for rotate", gameObject);
            return;
        }
        ChangeAnimatorState(true);
        sceneAnimator.Play(animationName);
    }
    
    private void ChangeAnimatorState(bool state)
    {
        sceneAnimator.enabled = state;
    }
    private bool CheckAnimatorState()
    {
        return sceneAnimator.enabled;
    }
    private static int Randomizer(int min, int max)
    {
        return Random.Range(min, max);;
    }
}
