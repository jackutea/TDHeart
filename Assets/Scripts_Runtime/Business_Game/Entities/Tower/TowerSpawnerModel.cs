using System;
using UnityEngine;

namespace TDHeart {

    [Serializable]
    public class TowerSpawnerModel {

        public TowerWaveModel[] waves;
        public int waveNumber; // 当前第几波

        // Path
        public Vector3Int[] path; // [0] is spawn point

        public TowerSpawnerModel() {
        }

    }

}