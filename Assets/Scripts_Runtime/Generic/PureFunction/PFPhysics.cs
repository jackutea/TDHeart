using UnityEngine;

namespace TDHeart {

    public static class PFPhysics {

        public static bool Overlap_Sphere_Sphere(Vector3 center1, float radius1, Vector3 center2, float radius2) {
            float disSqr = Vector3.SqrMagnitude(center1 - center2);
            float radiusSum = radius1 + radius2;
            return disSqr <= radiusSum * radiusSum;
        }

    }
}