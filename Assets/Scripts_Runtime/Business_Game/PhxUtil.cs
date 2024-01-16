using UnityEngine;

namespace TDHeart {

    public static class PhxUtil {

        public static PropEntity Overlap_Prop(GameContext ctx, AllyFlag allyFlag, Vector3 center, float radius) {
            var prop = ctx.propRepository.Find(value => {
                if (value.allyFlag != allyFlag) {
                    return false;
                } else {
                    return PFPhysics.Overlap_Sphere_Sphere(center, radius, value.lpos, 0.5f);
                }
            });
            return prop;
        }

    }

}