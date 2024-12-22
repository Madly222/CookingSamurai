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
        sceneAnimator.SetInteger(PrepareID, Randomizer(1,2));
        sceneAnimator.SetBool(IsTrash, isTrash);
    }
    
    public void DisableAnimator()
    {
        sceneAnimator.SetInteger(PrepareID, 0);
        sceneAnimator.enabled = false;
    }

    public void PlaySellAnimation()
    {
        
    }
    
    public void RotateCamera(string state)
    {
        if (CheckAnimatorState())
        {
            Logger.Log("Wait for rotate", gameObject);
            return;
        }
        ChangeAnimatorState(true);
        
        switch (state)
        {
            case "right":
                sceneAnimator.Play("RotateRight");
                return;
            case "left":
                sceneAnimator.Play("RotateLeft");
                return;
            default:
                Logger.LogError("Rotation camera error", gameObject);
                return;
        }
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
