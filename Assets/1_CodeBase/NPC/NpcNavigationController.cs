using UnityEngine;

public class NpcNavigationController : MonoBehaviour
{
    [SerializeField] private Transform[] navigationPoint;
    [SerializeField] private bool[] pointIsTaken;
    [SerializeField] private CustomerBrain[] customerBrain;

    private int _numberOfNpc;

    [SerializeField] private  enum CounterPoint
    {
        WaitInQueue,
        WaitSell,
        Sit
    }
    
    [SerializeField] private CounterPoint[] pointTypes;

    public bool RequestTask()
    {
        return _numberOfNpc < navigationPoint.Length;
    }
    
    private int _npcInQueue;
    private bool _haveFreePoint;
    public bool CheckQueue(CustomerBrain thisCustomerBrain)
    {
        //if (counterPoint.Length > customerBrain.Length)
            _haveFreePoint = true;
        //else
            return false;
        
        customerBrain[_npcInQueue] = thisCustomerBrain;
        
        return _haveFreePoint;
    }

    //public Transform TakePoint()
    //{
        //return counterPoint[_npcInQueue];
    //}
}
