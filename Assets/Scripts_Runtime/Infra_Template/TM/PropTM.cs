using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "PropTM", menuName = "TDHeart/PropTM", order = 0)]
    public class PropTM : ScriptableObject {

        public int typeID;
        public string typeName;

        public GameObject modPrefab;

    }

}