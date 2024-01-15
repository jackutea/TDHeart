using UnityEngine;

namespace TDHeart {

    public class RoleEntity : MonoBehaviour {

        public int id;
        public AllyFlag allyFlag;
        public Vector3 lpos;

        // Move
        public RoleMoveModel moveModel;

        public void Ctor() {
            moveModel = new RoleMoveModel();
        }

        public void SetRPos(Vector3 rpos) {
            transform.position = rpos;
        }

        public void Move_ByPath(float fixdt) {
            var move = moveModel;
            if (move.path == null) {
                return;
            }

            if (move.pathIndex >= move.path.Length) {
                return;
            }

            Vector3 target = move.path[move.pathIndex];
            Vector3 dir = target - transform.position;
            float speed = 1f;
            float dist = speed * fixdt;
            if (dir.magnitude <= dist) {
                transform.position = target;
                move.pathIndex++;
            } else {
                transform.position += dir.normalized * dist;
            }

        }

    }

}