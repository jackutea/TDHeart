using UnityEngine;

namespace TDHeart {

    public static class BulletDomain {

        public static BulletEntity Spawn(GameContext ctx, int typeID, AllyFlag allyFlag, Vector3 pos) {
            BulletEntity bullet = GameFactory.Bullet_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, pos);
            ctx.bulletRepository.Add(bullet);
            return bullet;
        }

        public static BulletEntity Unspawn(GameContext ctx, BulletEntity bullet) {
            bullet.TearDown();
            ctx.bulletRepository.Remove(bullet);
            return bullet;
        }

        public static void Fly(GameContext ctx, BulletEntity bullet, float fixdt) {
            bullet.Fly(fixdt);
        }

        public static void Overlap(GameContext ctx, BulletEntity bullet) {
            int roleCount = PhxUtil.Overlap_Roles(ctx, bullet.allyFlag.Opposite(), bullet.lpos, 0.2f, out var roles);
            for (int i = 0; i < roleCount; i++) {
                var role = roles[i];
                // Hurt
                RoleDomain.Hurt(ctx, role, 1);
            }
            if (roleCount > 0) {
                // Unspawn
                Unspawn(ctx, bullet);
            }
        }

    }

}