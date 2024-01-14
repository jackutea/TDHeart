using UnityEngine;

namespace TDHeart {

    public class RoleEntity : MonoBehaviour {

        public int id;
        public AllyFlag allyFlag;
        public Vector3 lpos;

        public void SetRPos(Vector3 rpos) {
            transform.position = rpos;
        }

    }

}