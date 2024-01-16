using UnityEngine;

namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            TowerDomain.Spawn(ctx, 1, new Vector3Int(0, 0, 10), AllyFlag.Monster); // Cave
            PropDomain.Spawn(ctx, 1, new Vector3Int(0, 0, 0)); // DeadLine
        }

        public static void PreTick(GameContext ctx, float dt) {
            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
            }
        }

        public static void FixedTick(GameContext ctx, float fixdt) {
            int towerLen = ctx.towerRepository.TakeAll(out var towers);
            for (int i = 0; i < towerLen; i += 1) {
                var tower = towers[i];
                TowerDomain.Spawner_TrySpawn(ctx, tower, fixdt);
            }

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
                RoleDomain.Move_Auto(ctx, role, fixdt);
                RoleDomain.Overlap_DeadLine(ctx, role);
            }
        }

        public static void PostTick(GameContext ctx, float dt) {
            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
            }
        }

    }

}