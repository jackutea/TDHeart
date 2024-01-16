using UnityEngine;

namespace TDHeart {

    public static class PhxUtil {

        public static PropEntity Overlap_Prop(GameContext ctx, Vector3 center, float radius) {
            var prop = ctx.propRepository.Find(value => {
                return PFPhysics.Overlap_Sphere_Sphere(center, radius, value.lpos, 0.5f);
            });
            return prop;
        }

    }

}