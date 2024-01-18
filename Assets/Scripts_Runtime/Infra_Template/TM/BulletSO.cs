using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "SO_Bullet_", menuName = "TDHeart/SO_Bullet", order = 0)]
    public class BulletSO : ScriptableObject {
        
        public int typeID;
        public string typeName;

        public float moveSpeed;

        public GameObject modPrefab;

    }

}