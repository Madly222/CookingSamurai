using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerBrain : MonoBehaviour
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

   private void OnEnable()
   {
       npcNavigationController.TakeNpc(this);
   }
   public void WalkTo(string positionName, Transform targetPoint)
   {
       _positionName = positionName;
       _targetPoint = targetPoint;
       StartCoroutine(WalkToPoint());
   }
   private void PointReached()
   {
       switch (_positionName)
       {
           case "Exit":
               animator.SetLayerWeight(1, 0f);
               gameObject.SetActive(false);
               break;
           case "InQueue":
                
               break;
           case "ActivePoint":
               SellButton.OnSell += TakeItem;
               break;
           
           default:
               Debug.LogError("No name of position to walk", gameObject);
               gameObject.SetActive(false);
               break;
       }
   }
   public void DisableOnExit(Transform targetPoint)
   {
       _positionName = "Exit";
       _targetPoint = targetPoint;
       StartCoroutine(WalkToPoint());
   }
   
   private void TakeItem()
   {
       StartCoroutine(TakeItemReaction());
   }
   
   private void SmoothRotate(Transform targetRotation)
   {
       transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, _rotationSpeed * Time.deltaTime);
   }
   
   IEnumerator WalkToPoint()
   {
       /*while (Quaternion.Angle(transform.rotation, _targetPoint.rotation) > 1f)
       {
           SmoothRotate(_targetPoint);
           yield return null;
       }*/
       
       animator.SetBool("Walk", true);
       navMeshAgent.SetDestination(_targetPoint.position);

       yield return new WaitUntil(() => !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance);
       
       animator.SetBool("Walk", false);
       
       while (Quaternion.Angle(transform.rotation, _targetPoint.rotation) > 1f)
       {
           SmoothRotate(_targetPoint);
           yield return null;
       }

       PointReached();
   }

   IEnumerator TakeItemReaction()
   {
       _f = 0;
       while (_f < 1f)
       {
           _f += Time.deltaTime;
           _f = Mathf.Clamp(_f, 0f, 1f);
           animator.SetLayerWeight(1, _f);
           yield return null;
       }
       npcNavigationController.GiveSitPoint(this);
       SellButton.OnSell -= TakeItem;
   }
}
