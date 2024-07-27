using CodeBase;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] private Image toStart;
    [SerializeField] private TMP_Text text;
    [SerializeField] private ItemManager spawnerFood;

    [SerializeField] private bool isSpawning;

    public void ChangeMode()
    {
        if (isSpawning)
        {
            toStart.color = Color.green;
            spawnerFood.SpawnMode(isSpawning);
            isSpawning = false;
            text.text = "Tap to start spawn";
        }
        else
        {
            toStart.color = Color.red;
            spawnerFood.SpawnMode(isSpawning);
            isSpawning = true;
            text.text = "Tap to finish spawn";
        }
    }
}
