using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "SO_Prop_", menuName = "TDHeart/SO_Prop", order = 0)]
    public class PropSO : ScriptableObject {

        public int typeID;
        public string typeName;

        public GameObject modPrefab;

    }

}