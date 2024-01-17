using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    [Serializable]
    public class TowerSpawnerModel {

        public TowerWaveModel[] waves;
        public int waveNumber; // 当前第几波
        public int waveNumberMax; // 最大波数

        public HashSet<int> spawnedEnemyIDs;

        // Path
        public Vector3Int[] path; // [0] is spawn point

        public TowerSpawnerModel() {
            spawnedEnemyIDs = new HashSet<int>();
        }

        public bool IsAllWaveClear() {

            if (waves == null || waves.Length == 0) {
                return true;
            }

            if (waveNumber < waveNumberMax) {
                return false;
            }

            // last wave spawned
            for (int i = 0; i < waves.Length; i++) {
                ref TowerWaveModel wave = ref waves[i];
                if (wave.waveNumber == waveNumber) {
                    if (waves[i].count < waves[i].countMax) {
                        return false;
                    }
                }
            }

            // all spawned enemy dead
            return spawnedEnemyIDs.Count == 0;
        }

    }

}