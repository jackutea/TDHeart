using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "SO_Role_", menuName = "TDHeart/SO_Role", order = 0)]
    public class RoleSO : ScriptableObject {
        
        public int typeID;
        public string typeName;

        public int hp;
        public float moveSpeed;

        public GameObject modPrefab;

    }

}