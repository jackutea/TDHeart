using UnityEngine;

namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {

            var game = ctx.game;
            game.Normal_Enter();

            PlayerDomain.Spawn(ctx, 1);
            TowerDomain.Spawn(ctx, 1, new Vector3Int(0, 0, 10), AllyFlag.Monster); // Cave
            PropDomain.Spawn(ctx, 1, AllyFlag.Player, new Vector3Int(0, 0, 0)); // DeadLine

            UIApp.P_HeartInfo_Open(ctx.uiContext);

        }

        public static void Exit(GameContext ctx) {
            GameDomain.ExitGame(ctx);
        }

        public static void PreTick(GameContext ctx, float dt) {
            var game = ctx.game;
            if (game.status == GameStatus.Normal) {
                Normal_PreTick(ctx, dt);
            } else if (game.status == GameStatus.Failed) {
                Failed_PreTick(ctx, dt);
            }
        }

        public static void FixedTick(GameContext ctx, float fixdt) {
            var game = ctx.game;
            if (game.status == GameStatus.Normal) {
                Normal_FixedTick(ctx, fixdt);
            } else if (game.status == GameStatus.Failed) {
                Failed_FixedTick(ctx, fixdt);
            }
        }

        public static void PostTick(GameContext ctx, float dt) {
            var game = ctx.game;
            if (game.status == GameStatus.Normal) {
                Normal_PostTick(ctx, dt);
            } else if (game.status == GameStatus.Failed) {
                Failed_PostTick(ctx, dt);
            }
        }

        // ==== Normal ====
        static void Normal_PreTick(GameContext ctx, float dt) {
            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
            }
        }

        static void Normal_FixedTick(GameContext ctx, float fixdt) {
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

        static void Normal_PostTick(GameContext ctx, float dt) {

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
                role.R_Update();
            }

            UIApp.P_HeartInfo_SetHeart(ctx.uiContext, ctx.player.hp);

            // Sumup
            GameDomain.CheckGameResult(ctx);

        }

        // ==== Failed ====
        static void Failed_PreTick(GameContext ctx, float dt) {
            var game = ctx.game;
            if (game.failed_isEntering) {
                game.failed_isEntering = false;
                UIApp.P_Failed_Open(ctx.uiContext);
            }
        }

        static void Failed_FixedTick(GameContext ctx, float fixdt) {

        }

        static void Failed_PostTick(GameContext ctx, float dt) {

        }

    }

}