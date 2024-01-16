using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "SO_Tower_", menuName = "TDHeart/SO_Tower", order = 0)]
    public class TowerSO : ScriptableObject {
        
        public int typeID;
        public string typeName;

        public GameObject modPrefab;

    }

}