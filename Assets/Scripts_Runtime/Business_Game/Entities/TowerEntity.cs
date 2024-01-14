using System;
using UnityEngine;

namespace TDHeart {

    public class TowerEntity : MonoBehaviour {

        public int id;

        public Vector3Int lpos;

        public void SetRPos(Vector3Int rpos) {
            transform.position = rpos;
        }

    }

}