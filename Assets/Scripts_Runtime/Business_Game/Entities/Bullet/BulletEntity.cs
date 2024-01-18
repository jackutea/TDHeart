using UnityEngine;

namespace TDHeart {

    public class BulletEntity : MonoBehaviour {

        public int id;
        public readonly EntityType entityType = EntityType.Bullet;
        public AllyFlag allyFlag;
        public Vector3 lpos;

        public void Ctor(GameObject mod) {

        }

        public void Pos_Set(Vector3 pos) {
            transform.position = pos;
            lpos = pos;
        }

    }

}