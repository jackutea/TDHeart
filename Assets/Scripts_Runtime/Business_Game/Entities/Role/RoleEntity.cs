using UnityEngine;

namespace TDHeart {

    public class RoleEntity : MonoBehaviour {

        public int id;
        public AllyFlag allyFlag;
        public Vector3 lpos;

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

        public void DrawUI(Camera camera) {
            Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
            float screenH = Screen.height;
            GUI.DrawTexture(new Rect(screenPos.x, screenH - screenPos.y, 100, 10), Texture2D.whiteTexture);
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

            transform.LookAt(dir.normalized + transform.position);

        }

    }

}