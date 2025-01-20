using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerBrain : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    [SerializeField] private NpcNavigationController npcNavigationController;
    [SerializeField] private float timeToDisable;
    
    public enum NpcState
    {
        Walk,
        Wait,
        Sit
    }

    //public NpcState currentNpcState;
    
    
    private Transform _stopPoint;
    public bool onPosition;
    
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _stopDistance = 0.3f;
    [SerializeField] private float _distance;


    
    private bool _isCounterPoint;
    private static readonly int Wait = Animator.StringToHash("Wait");

    private void OnEnable()
    {
        if(!npcNavigationController.RequestTask())
            ToDoNpc(default);
    }

    public void ToDoNpc(NpcState currentNpcState)
    {
        switch (currentNpcState)
        {
            case NpcState.Walk:
                Debug.Log("npc walk");
                break;
            case NpcState.Wait:
                Debug.Log("npc Wait");
                break;
            case NpcState.Sit:
                Debug.Log("npc sit");
                break;
            default:
                StartCoroutine(DisableMe());
                break;
        }
    }
    
    
    public bool MoveToPoint(Transform targetPoint)
    {
        if (!targetPoint)
        {
            StartCoroutine(DisableMe());
            return false;
        }
        
        StartCoroutine(WalkAnimation(targetPoint));
        return true;
    }

    private IEnumerator WalkAnimation(Transform targetPoint)
    {
        npcAnimator.SetBool(Wait, false);
        
        _distance = Vector3.Distance(transform.position, targetPoint.position);

        yield return StartCoroutine(SmoothRotateToStopPoint(Quaternion.LookRotation(targetPoint.position - transform.position)));
        
        while (_distance > _stopDistance)
        {
            _distance = Vector3.Distance(transform.position, targetPoint.position);
            transform.rotation = Quaternion.LookRotation(targetPoint.position - transform.position);
            yield return null;
        }
        
        yield return StartCoroutine(SmoothRotateToStopPoint(targetPoint.rotation));
        onPosition = true;
    }

    private IEnumerator SmoothRotateToStopPoint(Quaternion lookPoint)
    {
        while (Quaternion.Angle(transform.rotation, lookPoint) > 1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookPoint, _rotationSpeed * 50f * Time.deltaTime);
            yield return null;
        }

        transform.rotation = lookPoint;
    }

    private IEnumerator DisableMe()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }
}
