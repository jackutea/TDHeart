using UnityEngine;

namespace TDHeart {

    public static class PropDomain {

        public static PropEntity Spawn(GameContext ctx, int typeID, Vector3 lpos) {
            var entity = GameFactory.Prop_Create(ctx.idService, typeID, lpos);
            ctx.propRepository.Add(entity);
            return entity;
        }
    
    }
}