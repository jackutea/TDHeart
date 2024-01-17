using UnityEngine;

namespace TDHeart {

    public static class GameDomain {

        public static void EnterGame(GameContext ctx) {
            var game = ctx.game;
            game.Normal_Enter();

            PlayerDomain.Spawn(ctx, 1);
            TowerDomain.Spawn(ctx, 100, new Vector3Int(0, 0, 10), AllyFlag.Monster); // Cave
            PropDomain.Spawn(ctx, 100, AllyFlag.Player, new Vector3Int(0, 0, 0)); // DeadLine

            UIApp.P_HeartInfo_Open(ctx.uiContext);
        }

        public static void ExitGame(GameContext ctx) {

            var game = ctx.game;
            var player = ctx.player;
            game.status = GameStatus.None;

            int towerLen = ctx.towerRepository.TakeAll(out var towers);
            for (int i = 0; i < towerLen; i += 1) {
                TowerEntity tower = towers[i];
                tower.TearDown();
                ctx.towerRepository.Remove(tower);
            }

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i += 1) {
                RoleEntity role = roles[i];
                role.TearDown();
                ctx.roleRepository.Remove(role);
            }

            int propLen = ctx.propRepository.TakeAll(out var props);
            for (int i = 0; i < propLen; i += 1) {
                PropEntity prop = props[i];
                prop.TearDown();
                ctx.propRepository.Remove(prop);
            }

            UIApp.P_HeartInfo_Close(ctx.uiContext);

        }

        public static void CheckGameResult(GameContext ctx) {

            var game = ctx.game;
            var player = ctx.player;

            if (player.hp <= 0) {
                game.Failed_Enter();
                return;
            }

            int towerLen = ctx.towerRepository.TakeAll(out var towers);
            for (int i = 0; i < towerLen; i += 1) {
                TowerEntity tower = towers[i];
                if (tower.allyFlag == AllyFlag.Monster) {
                    if (!tower.spawnerModel.IsAllWaveClear()) {
                        return;
                    }
                }
            }
            game.Win_Enter();

        }

    }

}