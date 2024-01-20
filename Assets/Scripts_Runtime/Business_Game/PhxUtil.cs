using UnityEngine;

namespace TDHeart {

    public static class PhxUtil {

        static RoleEntity[] tempFindResults = new RoleEntity[100];
        public static int Overlap_Roles(GameContext ctx, AllyFlag allyFlag, Vector3 center, float radius, out RoleEntity[] outRoles) {
            int count = 0;
            ctx.roleRepository.Foreach(value => {
                if (value.allyFlag != allyFlag) {
                    return;
                }
                if (PFPhysics.Overlap_Sphere_Sphere(center, radius, value.lpos, 0.5f)) {
                    tempFindResults[count] = value;
                    count++;
                }
            });
            outRoles = tempFindResults;
            return count;
        }

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