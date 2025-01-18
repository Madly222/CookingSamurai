using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;
    [SerializeField] private Transform[] counterPoint;
    [SerializeField] private GameObject[] pedestrian;

    [SerializeField] private int minSpawnRate = 5;
    [SerializeField] private int maxSpawnRate = 20;
    [SerializeField] private int customerSpawnTime = 5;
    [SerializeField] private int disableTime = 20; 

    private int _randomPedestrian;
    private int _randomPoint;

   private int[] _customerId;
    
    private void Start()
    {
        StartCoroutine(EnablePedestrianCd());
    }

    
    
    private IEnumerator EnableCustomer()
    {
        while (true)
        {
            yield return new WaitForSeconds(customerSpawnTime);
            if (_customerId.Length > 2) continue;
            
            _randomPedestrian = Randomizer(0, pedestrian.Length);
            _randomPoint = Randomizer(0, startPoint.Length);
            
            if (pedestrian[_randomPedestrian].activeSelf) continue;
            pedestrian[_randomPedestrian].transform.position = startPoint[_randomPoint].position;
            pedestrian[_randomPedestrian].transform.rotation = startPoint[_randomPoint].rotation;
            pedestrian[_randomPedestrian].SetActive(true);
        }
    }

    private IEnumerator EnablePedestrianCd()
    {
        while (true)
        {
            yield return new WaitForSeconds(Randomizer(minSpawnRate, maxSpawnRate));
            _randomPedestrian = Randomizer(0, pedestrian.Length);
            _randomPoint = Randomizer(0, startPoint.Length);
            
            if (pedestrian[_randomPedestrian].activeSelf) continue;
            pedestrian[_randomPedestrian].transform.position = startPoint[_randomPoint].position;
            pedestrian[_randomPedestrian].transform.rotation = startPoint[_randomPoint].rotation;
            pedestrian[_randomPedestrian].SetActive(true);
        }
    }
    
    
    private static int Randomizer(int min, int max)
    {
        return Random.Range(min, max);;
    }
    
}
