namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            TowerDomain.Spawn(ctx, 1, new UnityEngine.Vector3Int(0, 5, 0));
            RoleDomain.Spawn(ctx, 1, new UnityEngine.Vector3(5, 0, 0));
        }

        public static void FixedTick(GameContext ctx, float fixdt) {
            int towerLen = ctx.towerRepository.TakeAll(out var towers);
            for (int i = 0; i < towerLen; i += 1) {
                var tower = towers[i];
                TowerDomain.Spawner_TrySpawn(ctx, tower, fixdt);
            }
        }

    }

}