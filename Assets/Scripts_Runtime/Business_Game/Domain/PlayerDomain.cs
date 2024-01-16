namespace TDHeart {

    public static class PlayerDomain {

        public static PlayerEntity Spawn(GameContext ctx, int typeID) {
            var player = GameFactory.Player_Create(ctx.templateContext, ctx.idService, typeID);
            ctx.player = player;
            return player;
        }

        public static void Hurt(GameContext ctx, int damage) {
            ctx.player.hp -= damage;
            if (ctx.player.hp <= 0) {
                ctx.player.hp = 0;
            }
        }

    }

}