using UnityEngine;

namespace TDHeart {

    public class RoleEntity : MonoBehaviour {

        public int id;
        public readonly EntityFlag entityType = EntityFlag.Role;
        public int belongTowerID;
        public AllyFlag allyFlag;
        public Vector3 lpos;
        public Vector3 ldir;

        public int hp;
        public int hpMax;

        // Move
        public RoleMoveModel moveModel;

        // Renderer
        public RoleRendererModel rendererModel;

        public void Ctor(GameObject mod) {
            moveModel = new RoleMoveModel();
            rendererModel = new RoleRendererModel();
            rendererModel.Ctor(mod);
        }

        public void TearDown() {
            rendererModel.TearDown();
            GameObject.Destroy(gameObject);
        }

        public void DrawUI(Camera camera) {
            Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
            float screenH = Screen.height;
            GUI.DrawTexture(new Rect(screenPos.x, screenH - screenPos.y, 100, 10), Texture2D.whiteTexture);
        }

        public void Pos_Set(Vector3 rpos) {
            lpos = rpos;
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
            ldir = target - lpos;
            float speed = 1f;
            float dist = speed * fixdt;
            if (ldir.magnitude <= dist) {
                lpos = target;
                move.pathIndex++;
            } else {
                lpos += ldir.normalized * dist;
            }

        }

        public void R_Update() {
            transform.position = lpos;
            transform.LookAt(ldir.normalized + lpos);
        }

    }

}