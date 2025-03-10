using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcNavigationController : MonoBehaviour
{
    [SerializeField] private GameObject[] inQueuePoints;
    [SerializeField] private GameObject[] sittingPoints;
    [SerializeField] private GameObject[] exitPoints;
    
    [SerializeField] private List<CustomerBrain> _inQueueNpc = new();
    
    private int _index;
    private static readonly int Buy = Animator.StringToHash("Buy");

    private void OnEnable()
    {
        SellButton.OnSell += SellFood;
    }

    private void OnDisable()
    {
        SellButton.OnSell -= SellFood;
    }

    public void TakeNpc(CustomerBrain thisCustomer)
    {
        if (_inQueueNpc.Count < inQueuePoints.Length)
        {
            GiveQueuePoint(thisCustomer);
            return;
        }
        
        TakeExitPoint(thisCustomer);
    }

    private void GiveQueuePoint(CustomerBrain thisCustomer)
    {
        for (_index = 0;_index < inQueuePoints.Length;_index++)
        {
            if (inQueuePoints[_index].activeSelf) continue;
            
            thisCustomer.WalkTo("QueueP",inQueuePoints[_index].transform);
            inQueuePoints[_index].SetActive(true);
            _inQueueNpc.Add(thisCustomer);
            Debug.Log("Npc taken active point", inQueuePoints[_index]);
            return;
        }
        
        TakeExitPoint(thisCustomer);
        Debug.Log("No active point available for", thisCustomer);
    }

    private void SellFood()
    {
        StartCoroutine(CustomerBuy());
    }
    public void GiveSitPoint(CustomerBrain thisCustomer)
    { 
        //StartCoroutine(QueueMove());
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
        thisCustomer.WalkTo("EndP", exitPoints[Randomize(0,exitPoints.Length)].transform);
    }

    private IEnumerator CustomerBuy()
    {
        _inQueueNpc[0].HandAnimation();
        yield return new WaitForSeconds(2.5f);
        TakeExitPoint(_inQueueNpc[0]);
        _inQueueNpc.RemoveAt(0);
        yield return new WaitForSeconds(0.5f);
        for (_index = 0; _index < _inQueueNpc.Count; _index++)
        {
            _inQueueNpc[_index].WalkTo("QueueP", inQueuePoints[_index].transform);
            yield return new WaitForSeconds(0.5f);
        }

        var inactiveCount = inQueuePoints.Length - _inQueueNpc.Count;
        for (_index = 0; _index < inactiveCount; _index++)
        {
            inQueuePoints[^ (_index + 1)].SetActive(false);
        }
    }
    
    private static int Randomize(int min, int max)
    {
        return Random.Range(min, max);
    }
}
