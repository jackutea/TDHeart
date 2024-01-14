using UnityEngine;

namespace TDHeart {

    public class TowerSpawnerModel {

        public bool isEnable;

        public float cd;
        public float cdMax;

        public float maintain;
        public float maintainTimer;
        public float interval;
        public float intervalTimer;
        public float typeID;

        // Path
        public Vector3Int[] path; // [0] is spawn point

        public void Fake() {

            isEnable = true;

            cd = 0;
            cdMax = 1;

            maintain = 1;
            maintainTimer = 0;
            interval = 0.1f;
            intervalTimer = 0.1f;
            typeID = 1;

            path = new Vector3Int[] {
                new Vector3Int(0, 0, 10),
                new Vector3Int(0, 0, 0),
            };
        }

    }

}