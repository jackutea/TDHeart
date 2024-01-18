using UnityEngine;

namespace TDHeart {

    public class CellEntity : MonoBehaviour {

        public int id;
        public Vector3Int lpos;

        public void Pos_Set(Vector3Int lpos) {
            this.lpos = lpos;
            transform.localPosition = lpos;
        }

    }

}