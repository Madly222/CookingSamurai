using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableStorage", menuName = "ScriptableObjects/SpawnableStorage", order = 1)]
public class SpawnableStorage : ScriptableObject
{
    [System.Serializable]
    public class PrefabEntry
    {
        public int id;
        public GameObject prefab;
    }
    
    public PrefabEntry[] prefabs;
}
