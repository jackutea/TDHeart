namespace TDHeart {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            TowerDomain.Spawn(ctx, 1, new UnityEngine.Vector3Int(0, 5, 0));
        }

        public static void Tick(GameContext ctx, float dt) {

        }

    }

}