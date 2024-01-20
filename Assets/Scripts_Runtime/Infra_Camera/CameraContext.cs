using UnityEngine;

namespace TDHeart {

    public class CameraContext {

        public Camera mainCamera;

        public CameraContext() { }

        public void Inject(Camera mainCamera) {
            this.mainCamera = mainCamera;
        }

    }

}