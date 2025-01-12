using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPedestrian : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;
    [SerializeField] private GameObject[] pedestrian;

    [SerializeField] private int minSpawnRate = 5;
    [SerializeField] private int maxSpawnRate = 20;

    private int _randomPedestrian;
    private int _randomPoint;
    
    private void Start()
    {
        StartCoroutine(SpawnNpc());
    }

    private IEnumerator SpawnNpc()
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
