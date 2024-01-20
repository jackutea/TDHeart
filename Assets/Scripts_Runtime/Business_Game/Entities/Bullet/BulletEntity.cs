using UnityEngine;

namespace TDHeart {

    public class BulletEntity : MonoBehaviour {

        public int id;
        public readonly EntityFlag entityType = EntityFlag.Bullet;
        public AllyFlag allyFlag;

        public Vector3 lpos;
        public Vector3 ldir;

        // Fly
        public float flySpeed;
        public Vector3 targetDir;
        public Vector3 targetPos;

        public void Ctor(GameObject mod) {

        }

        public void TearDown() {
            GameObject.Destroy(gameObject);
        }

        public void R_Update() {
            transform.position = lpos;
            transform.LookAt(ldir.normalized + lpos);
        }

        public void Pos_Set(Vector3 pos) {
            transform.position = pos;
            lpos = pos;
        }

        public void Fly(float fixdt) {
            Vector3 pos = lpos;
            Vector3 dir = targetPos - pos;
            float distance = dir.magnitude;
            if (distance <= 0.1f) {
                pos = targetPos;
                ldir = dir;
                return;
            }
            dir /= distance;

            float moveDistance = flySpeed * fixdt;
            if (moveDistance >= distance) {
                pos = targetPos;
                ldir = dir;
                return;
            }

            pos += dir * moveDistance;
            ldir = dir;
            lpos = pos;
        }

    }

}