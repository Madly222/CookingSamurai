using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class ItemDropper : MonoBehaviour
{
    //[SerializeField] private CookController cookController;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private List<Transform> spawnPoint = new();
    [SerializeField] public List<GameObject> goodFood;
    [SerializeField] public List<GameObject> trash;

    private const int BaseTrashChance = 5;
    private int _rndNum;

    private Coroutine _dropCooldownCoroutine;
    private void OnEnable()
    {
        _dropCooldownCoroutine = StartCoroutine(DropCooldown());
    }

    private void OnDisable()
    {
        StopCoroutine(_dropCooldownCoroutine);
    }

    private void SelectItem()
    {
        CheckItem(Random.Range(0, levelManager.goodFoodChance + 7) <= BaseTrashChance ? trash : goodFood);
    }
    
    private void CheckItem(List<GameObject> items)
    {
        _rndNum = Random.Range(0, items.Count);
        if (!items[_rndNum].activeSelf)
        {
            DropItem(items[_rndNum]);
            return;
        }
        foreach (var go in items.Where(t => !t.activeSelf))
        {
            DropItem(go);
            return;
        }

        _dropCooldownCoroutine = StartCoroutine(DropCooldown());
    }

    private void DropItem(GameObject item)
    {
        _rndNum = Random.Range(0, spawnPoint.Count);
        item.transform.SetPositionAndRotation(spawnPoint[_rndNum].position, spawnPoint[_rndNum].rotation);
        item.SetActive(true);
        _dropCooldownCoroutine = StartCoroutine(DropCooldown());
    }
    
    private IEnumerator DropCooldown()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, levelManager.maxSpawnSpeed));
        SelectItem();
    }
}

