using UnityEngine;

namespace TDHeart {

    public static class CameraInfra {

        public static Vector3 Pos(this CameraContext ctx) {
            Vector3 pos = ctx.mainCamera.transform.position;
            return pos;
        }

        public static Vector3 Forward(this CameraContext ctx) {
            return ctx.mainCamera.transform.forward;
        }

    }

}