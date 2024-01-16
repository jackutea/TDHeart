using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "TowerTM", menuName = "TDHeart/TowerTM", order = 0)]
    public class TowerTM : ScriptableObject {
        
        public int typeID;
        public string typeName;

        public GameObject modPrefab;

    }

}