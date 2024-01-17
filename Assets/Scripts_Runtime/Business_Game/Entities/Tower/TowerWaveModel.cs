using System;

namespace TDHeart {

    [Serializable]
    public struct TowerWaveModel {

        public int waveNumber;

        public float cd;
        public float cdMax;

        public float maintain;
        public float maintainTimer;

        public float interval;
        public float intervalTimer;

        public int typeID;
        public int count;
        public int countMax;

    }

}