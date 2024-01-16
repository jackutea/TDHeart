using System;
using UnityEngine;

namespace TDHeart {

    [Serializable]
    public class RoleRendererModel {

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
        }

        public void TearDown() {
            GameObject.Destroy(mod);
        }

    }

}