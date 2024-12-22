using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SpawnerFood : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        private int _rndIndex;
        
        [SerializeField] private List<GameObject> spawnPoint = new();
        
        [SerializeField] public List<GameObject> nonPreparable = new();
        [SerializeField] public List<GameObject> preparable = new();
        
        [SerializeField] private int goodFoodChance;

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
        }
        
        private void Spawning()
        {
            if (Physics.simulationMode != SimulationMode.Script)
            {
                _temp = TakePoint(spawnPoint);
                Instantiate(TakeItem(),_temp.transform.position , _temp.transform.rotation);
            }
            _timer = StartCoroutine(Coldown());
        }

       private GameObject TakeItem()
        {
            var rnd = Random.Range(0, levelManager.goodFoodChance);
            var randomIndex = 0;

            if (rnd < 5 && nonPreparable.Count > 0) 
            {
                randomIndex = Random.Range(0, nonPreparable.Count);
                return nonPreparable[randomIndex];
            }

            if (preparable.Count > 0)
            {
                randomIndex = Random.Range(0, preparable.Count);
                return preparable[randomIndex];
            }
            
            Debug.LogWarning("Оба списка пусты, возвращаю null.");
            return null;
        }
        
        private GameObject TakePoint(List<GameObject> point)
        {
            return point[Random.Range(0, point.Count)];
        }
        
        private IEnumerator Coldown()
        {
            yield return new WaitForSeconds(Random.Range(0.1f, levelManager.maxSpawnSpeed));
            Spawning();
        }
    }
