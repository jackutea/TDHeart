using UnityEngine;

namespace TDHeart {

    public class PropEntity : MonoBehaviour {

        public int id;
        public readonly EntityFlag entityType = EntityFlag.Prop;
        public AllyFlag allyFlag;
        public Vector3 lpos;

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
        }

        public void TearDown() {
            GameObject.Destroy(mod);
            GameObject.Destroy(gameObject);
        }

        public void Pos_Set(Vector3 pos) {
            transform.position = pos;
            lpos = pos;
        }

    }

}