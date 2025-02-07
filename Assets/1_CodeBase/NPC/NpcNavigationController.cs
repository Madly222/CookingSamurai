using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcNavigationController : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPoints;
    [SerializeField] private GameObject[] inQueuePoints;
    [SerializeField] private GameObject[] sittingPoints;
    [SerializeField] private GameObject[] exitPoints;
    
    
    [SerializeField] private List<CustomerBrain> _customerNpc = new();
    [SerializeField] private List<CustomerBrain> _inQueueNpc = new();
    //[SerializeField] private List<CustomerBrain> _sittingNpc = new();

    private int _index;

    public void TakeNpc(CustomerBrain thisCustomer)
    {
        if (_customerNpc.Count < customerPoints.Length)
        {
            GiveActivePoint(thisCustomer);
            return;
        }

        if (_inQueueNpc.Count < inQueuePoints.Length)
        {
            GiveQueuePoint(thisCustomer);
            return;
        }   
        TakeExitPoint(thisCustomer);
    }

    private void GiveActivePoint(CustomerBrain thisCustomer)
    {
        for (_index = 0;_index < customerPoints.Length;_index++)
        {
            if (!customerPoints[_index].activeSelf)
            {
                thisCustomer.WalkTo("ActivePoint",customerPoints[_index].transform);
                customerPoints[_index].SetActive(true);
                _customerNpc.Add(thisCustomer);
                Debug.Log("Npc taken active point", customerPoints[_index]);
                return;
            }
        }
        
        TakeExitPoint(thisCustomer);
        Debug.Log("No active point available", thisCustomer);
    }
    private void GiveQueuePoint(CustomerBrain thisCustomer)
    {
        for (_index = 0;_index < inQueuePoints.Length;_index++)
        {
            if (!inQueuePoints[_index].activeSelf)
            {
                thisCustomer.WalkTo("InQueue",inQueuePoints[_index].transform);
                inQueuePoints[_index].SetActive(true);
                _inQueueNpc.Add(thisCustomer);
                Debug.Log("Npc taken queue point", inQueuePoints[_index]);
                return;
            }
        }
        
        TakeExitPoint(thisCustomer);
        Debug.Log("No queue point available", thisCustomer);
    }
    
    public void GiveSitPoint(CustomerBrain thisCustomer)
    { 
        QueueMove();
        if (sittingPoints == null || sittingPoints.Length == 0)
        {
            TakeExitPoint(thisCustomer);
            return;
        }
        
        _index = Randomize(0, sittingPoints.Length);
        
        if (sittingPoints[_index].activeSelf) 
        {
           TakeExitPoint(thisCustomer);
           return; 
        }
        
        thisCustomer.WalkTo("Sit",sittingPoints[_index].transform); 
        sittingPoints[_index].SetActive(true); 
        Debug.Log("Npc taken sit point", sittingPoints[_index]);
    }

    private void TakeExitPoint(CustomerBrain thisCustomer)
    {
        thisCustomer.DisableOnExit(exitPoints[Randomize(0,exitPoints.Length)].transform);
    }

    private void QueueMove() //here
    {
        if (_inQueueNpc.Count > 0)
        {
            _customerNpc[0] = _inQueueNpc[0];
            _inQueueNpc.RemoveAt(0);
            
            
            for (int i = 0;i < _inQueueNpc.Count; i++)
            {
                
            }
        }

    }

    private static int Randomize(int min, int max)
    {
        return Random.Range(min, max);
    }
}
