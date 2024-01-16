namespace TDHeart {

    public static class GameDomain {

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

        }

        public static void CheckGameResult(GameContext ctx) {

            var game = ctx.game;
            var player = ctx.player;

            if (player.hp <= 0) {
                game.Failed_Enter();
                return;
            }

        }

    }

}