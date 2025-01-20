using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomNpcEnabler : MonoBehaviour
{
    [SerializeField] private Transform[] startPoint;
    [SerializeField] private GameObject[] pedestrian;

    [SerializeField] private int minSpawnRate = 5;
    [SerializeField] private int maxSpawnRate = 20;

    private int _randomPedestrianIndex;
    private int _randomPoint;

   private int _i;
    
    private void Start()
    {
        StartCoroutine(EnablePedestrianCd());
    }

    private IEnumerator EnablePedestrianCd()
    {
        while (true)
        {
            yield return new WaitForSeconds(Randomizer(minSpawnRate, maxSpawnRate));
            if (!SelectNpc()) continue; //if no inactive npc, dont take it
            SelectStartPoint();
            pedestrian[_randomPedestrianIndex].transform.position = startPoint[_randomPoint].position;
            pedestrian[_randomPedestrianIndex].transform.rotation = startPoint[_randomPoint].rotation;
            pedestrian[_randomPedestrianIndex].SetActive(true);
        }
    }

    private bool SelectNpc()
    {
        _randomPedestrianIndex = Randomizer(0, pedestrian.Length);
        
        if(!pedestrian[_randomPedestrianIndex].activeSelf)
            return true;

        for (_i = 0; _i < pedestrian.Length; _i++)
        {
            if (pedestrian[_i].activeSelf) continue;
            _randomPedestrianIndex = _i;
            return true;
        }
        
        return false;
    }

    private void SelectStartPoint()
    {
        _randomPoint = Randomizer(0, startPoint.Length);
    }
    
    private static int Randomizer(int min, int max)
    {
        return Random.Range(min, max);;
    }
    
}
