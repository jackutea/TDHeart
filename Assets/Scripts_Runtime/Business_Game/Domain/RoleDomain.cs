using UnityEngine;

namespace TDHeart {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {
            RoleEntity role = GameFactory.Role_Create(ctx.templateContext, ctx.idService, typeID, pos);
            ctx.roleRepository.Add(role);
            return role;
        }
    }
}