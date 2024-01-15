using UnityEngine;

namespace TDHeart {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos, AllyFlag allyFlag) {
            RoleEntity role = GameFactory.Role_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, pos);
            ctx.roleRepository.Add(role);
            return role;
        }

        public static RoleEntity SpawnByTower(GameContext ctx, TowerEntity tower, int typeID) {
            RoleEntity role = Spawn(ctx, typeID, tower.lpos, tower.allyFlag);
            role.lpos = tower.spawnerModel.path[0];
            role.SetRPos(role.lpos);
            role.moveModel.path = tower.spawnerModel.path;
            return role;
        }

        public static void Move_Auto(GameContext ctx, RoleEntity role, float fixdt) {
            role.Move_ByPath(fixdt);
        }

    }
}