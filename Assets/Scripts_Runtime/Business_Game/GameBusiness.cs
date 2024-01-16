using UnityEngine;

namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {

            PlayerDomain.Spawn(ctx, 1);
            TowerDomain.Spawn(ctx, 1, new Vector3Int(0, 0, 10), AllyFlag.Monster); // Cave
            PropDomain.Spawn(ctx, 1, AllyFlag.Player, new Vector3Int(0, 0, 0)); // DeadLine

            UIApp.P_HeartInfo_Open(ctx.uiContext);

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
                RoleDomain.Overlap_Prop(ctx, role);
            }
        }

        public static void PostTick(GameContext ctx, float dt) {

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
                role.R_Update();
            }

            UIApp.P_HeartInfo_SetHeart(ctx.uiContext, ctx.player.hp);

        }

    }

}