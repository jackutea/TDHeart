using UnityEngine;

namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            GameDomain.EnterGame(ctx);
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
            } else if (game.status == GameStatus.Win) {
                Win_PreTick(ctx, dt);
            }
        }

        public static void FixedTick(GameContext ctx, float fixdt) {
            var game = ctx.game;
            if (game.status == GameStatus.Normal) {
                Normal_FixedTick(ctx, fixdt);
            } else if (game.status == GameStatus.Failed) {
                Failed_FixedTick(ctx, fixdt);
            } else if (game.status == GameStatus.Win) {
                Win_FixedTick(ctx, fixdt);
            }
        }

        public static void PostTick(GameContext ctx, float dt) {
            var game = ctx.game;
            if (game.status == GameStatus.Normal) {
                Normal_PostTick(ctx, dt);
            } else if (game.status == GameStatus.Failed) {
                Failed_PostTick(ctx, dt);
            } else if (game.status == GameStatus.Win) {
                Win_PostTick(ctx, dt);
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
                TowerDomain.Cast_TryCast(ctx, tower, fixdt);
            }

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
                RoleDomain.Move_Auto(ctx, role, fixdt);
                RoleDomain.Overlap_Prop(ctx, role);
            }

            int bulletLen = ctx.bulletRepository.TakeAll(out var bullets);
            for (int i = 0; i < bulletLen; i += 1) {
                var bullet = bullets[i];
                BulletDomain.Fly(ctx, bullet, fixdt);
            }
        }

        static void Normal_PostTick(GameContext ctx, float dt) {

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                var role = roles[i];
                RoleDomain.Render(ctx, role);
            }

            int bulletLen = ctx.bulletRepository.TakeAll(out var bullets);
            for (int i = 0; i < bulletLen; i += 1) {
                var bullet = bullets[i];
                bullet.R_Update();
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

        // ==== Win ====
        static void Win_PreTick(GameContext ctx, float dt) {
            var game = ctx.game;
            if (game.win_isEntering) {
                game.win_isEntering = false;
                UIApp.P_Win_Open(ctx.uiContext);
            }
        }

        static void Win_FixedTick(GameContext ctx, float fixdt) {

        }

        static void Win_PostTick(GameContext ctx, float dt) {

        }

    }

}