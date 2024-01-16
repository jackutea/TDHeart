using UnityEngine;

namespace TDHeart {

    public static class PropDomain {

        public static PropEntity Spawn(GameContext ctx, int typeID, AllyFlag allyFlag, Vector3 lpos) {
            var entity = GameFactory.Prop_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, lpos);
            ctx.propRepository.Add(entity);
            return entity;
        }
    
    }
}