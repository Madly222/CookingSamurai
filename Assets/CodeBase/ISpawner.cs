using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    interface ISpawner
    {
        public float minColdown { get; }
        public float maxColdown { get; }
        //List<GameObject> toSpawn{ get; }
        public void SpawnMode(bool isSpawning);
        IEnumerator Coldown();
    }
}
