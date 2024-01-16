using System;
using UnityEngine;

namespace TDHeart {

    [Serializable]
    public class RoleRendererModel {

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
        }

    }

}