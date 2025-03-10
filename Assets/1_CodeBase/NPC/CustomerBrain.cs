using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerBrain : MonoBehaviour, INPC
{ 
   [SerializeField] private NavMeshAgent navMeshAgent;
   [SerializeField] private Animator animator;
   [SerializeField] private NpcNavigationController npcNavigationController;
   
   private string _positionName;
   private Transform _targetPoint;
   private float _distance;
   private Quaternion _targetRotation;
   private Vector3 _lookPoint;
   private float _rotationSpeed = 180f;

   private float _f;
   
   private static readonly int Walk = Animator.StringToHash("Walk");

   private void OnEnable()
   {
       npcNavigationController.TakeNpc(this);
   }

   public void WalkTo(string pointType, Transform pointTransform)
   {
       _targetPoint = pointTransform;
       
       switch (pointType)
       {
           case "QueueP":
               StartCoroutine(WalkToPoint());
               break;
           case "SitP":
               StartCoroutine(WalkToPoint());
               break;
           case "EndP":
               StartCoroutine(WalkToPoint());
               StartCoroutine(DisableTimer());
               break;
           default:
               Log.Error("Wrong walk point type", gameObject);
               StartCoroutine(DisableTimer());
               break;
       }
   }

   public void PlayAnimation(int animationName, bool animationState)
   {
       animator.SetBool(animationName, animationState);
   }

   public void HandAnimation()
   {
       StartCoroutine(HandLayerUp());
   }

   private void SmoothRotate(Transform targetRotation)
   {
       transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, _rotationSpeed * Time.deltaTime);
   }

   private IEnumerator WalkToPoint()
   {
       /*while (Quaternion.Angle(transform.rotation, _targetPoint.rotation) > 1f)
       {
           SmoothRotate(_targetPoint);
           yield return null;
       }*/
       PlayAnimation(Walk, true);
       navMeshAgent.SetDestination(_targetPoint.position);
       
       yield return new WaitUntil(() => !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance);
       PlayAnimation(Walk, false);
       
       while (Quaternion.Angle(transform.rotation, _targetPoint.rotation) > 1f)
       {
           SmoothRotate(_targetPoint);
           yield return null;
       }
   }
   
   private IEnumerator HandLayerUp()
   {
       var elapsedTime = 0f;

       while (elapsedTime < 2f)
       {
           elapsedTime += Time.deltaTime;
           animator.SetLayerWeight(1, Mathf.Lerp(0, 1, elapsedTime / 2f));
           yield return null;
       }

       animator.SetLayerWeight(1, 1);
   }

   private IEnumerator DisableTimer()
   {
       yield return new WaitForSeconds(20f);
       gameObject.SetActive(false);
   }
}
