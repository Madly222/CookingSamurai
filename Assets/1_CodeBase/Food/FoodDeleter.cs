using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class FoodDeleter : MonoBehaviour
{
    [SerializeField] private float waitTime = 10f;
    void Start()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(waitTime);
        
        while (Physics.simulationMode == SimulationMode.Script)
            yield return new WaitForSeconds(waitTime*2);
        
        Destroy(gameObject);
    }
}
