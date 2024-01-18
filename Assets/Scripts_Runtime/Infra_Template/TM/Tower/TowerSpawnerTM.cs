using System;
using UnityEngine;

namespace TDHeart {

    [Serializable]
    public class TowerSpawnerTM {

        public bool isSpawner;

        public TowerWaveTM[] waves;

        // Path
        public Vector3Int[] path;

    }

}