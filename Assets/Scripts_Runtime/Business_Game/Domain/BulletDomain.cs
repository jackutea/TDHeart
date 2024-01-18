using UnityEngine;

namespace TDHeart {

    public static class BulletDomain {

        public static BulletEntity Spawn(GameContext ctx, int typeID, AllyFlag allyFlag, Vector3 pos) {
            BulletEntity bullet = GameFactory.Bullet_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, pos);
            ctx.bulletRepository.Add(bullet);
            return bullet;
        }

        public static void Fly(GameContext ctx, BulletEntity bullet, float fixdt) {
            bullet.Fly(fixdt);
        }

    }

}