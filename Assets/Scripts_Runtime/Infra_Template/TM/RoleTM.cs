using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "RoleTM", menuName = "TDHeart/RoleTM", order = 0)]
    public class RoleTM : ScriptableObject {
        
        public int typeID;
        public string typeName;

        public int hp;
        public float moveSpeed;

        public GameObject modPrefab;

    }

}