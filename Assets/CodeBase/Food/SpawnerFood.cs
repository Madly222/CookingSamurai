using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class ItemManager : MonoBehaviour, ISpawner
    {
        [Inject] 
        private SpawnableStorage _spawnableStorage;

        private Leveling _leveling;
        
        public float minColdown { get; }
        public float maxColdown { get; }
        //public List<GameObject> toSpawn { get; }
        
        [SerializeField] private List<GameObject> spawnPoint = new List<GameObject>();
        
        [SerializeField] private int goodFoodChance;

        [SerializeField] private float dropPower = 5f;

        private GameObject _temp;
        
        private int _randomIndex;
        private float _randomTimer;
    
        private Coroutine _timer;

        public void SpawnMode(bool isSpawning)
        {
            if (!isSpawning)
            {
                _timer = StartCoroutine(Coldown());  
            }
            else
                StopCoroutine(_timer);

            //if (_leveling.CurrentLevel == 1)
        }
        public void Spawning()
        {
            _temp = TakePoint(spawnPoint);
            if (Random.Range(0, 10 + goodFoodChance) <= 10)
                //Instantiate(TakeItem(things),_temp.transform.position , _temp.transform.rotation).GetComponent<Rigidbody>().AddForce(_temp.transform.forward * Random.Range(5f,6f), ForceMode.Impulse);
                Instantiate(TakeItem(_spawnableStorage),_temp.transform.position , _temp.transform.rotation).GetComponent<Rigidbody>().AddForce(_temp.transform.forward * dropPower, ForceMode.Impulse);
            else
                //Instantiate(TakeItem(ingredientList),_temp.transform.position , _temp.transform.rotation).GetComponent<Rigidbody>().AddForce(_temp.transform.forward * Random.Range(5f,6f), ForceMode.Impulse);
                Instantiate(TakeItem(_spawnableStorage),_temp.transform.position , _temp.transform.rotation).GetComponent<Rigidbody>().AddForce(_temp.transform.forward * dropPower, ForceMode.Impulse);
            
            _timer = StartCoroutine(Coldown());
        }

        private GameObject TakeItem(SpawnableStorage spawnable)
        {
            var randomIndex = Random.Range(0, spawnable.prefabs.Length);
            return spawnable.prefabs[randomIndex].prefab;
        }
        
        private GameObject TakePoint(List<GameObject> point)
        {
            return point[Random.Range(0, point.Count)];
        }

        public void SpawnFood(GameObject spawnable)
        {
            //if(Random.Range(0, goodFoodChance) >= 10)
             //RandomPoint(toSpawn);
        }
        public IEnumerator Coldown()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            Spawning();
        }
    }
}
