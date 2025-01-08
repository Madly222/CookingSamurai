using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator sceneAnimator;

    private AnimatorStateInfo _stateInfo;
    
    private static readonly int IsTrash = Animator.StringToHash("IsTrash");
    /*private void Awake()
    {
            cookEffect.transform.SetParent(effectPoint.transform);
        cookEffect.transform.localPosition = Vector3.zero;
        cookEffect.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        cookEffect.SetActive(false);
    }*/
    
    public void PrepareFood(bool isTrash)
    {
        if (CheckAnimatorState())
        {
            StartCoroutine(WaitForPrepare(isTrash));
            return;
        }
        
        ChangeAnimatorState(true);
        sceneAnimator.Play(Randomizer(1, 2) == 1 ? "prepare1" : "prepare2");
        
        sceneAnimator.SetBool(IsTrash, isTrash);
    }
    
    public void DisableAnimator()
    {
        sceneAnimator.enabled = false;
    }

    public bool PlaySellAnimation()
    {
        if (CheckAnimatorState())
            return true;
        
        ChangeAnimatorState(true);
        sceneAnimator.Play("Sell");
        return false;
    }
    
    public void RotateCamera(string animationName)
    {
        if (CheckAnimatorState())
            return;
        
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
        return Random.Range(min, max);
    }
    
    private IEnumerator WaitForPrepare(bool isTrash)
    {
         while (CheckAnimatorState())
         {
             yield return new WaitForSeconds(0.2f);
         }

         PrepareFood(isTrash);
    }
}
