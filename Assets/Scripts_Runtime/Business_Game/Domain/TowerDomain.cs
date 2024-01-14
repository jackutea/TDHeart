using UnityEngine;

namespace TDHeart {

    public static class TowerDomain {

        public static TowerEntity Spawn(GameContext ctx, int typeID, Vector3Int pos) {
            TowerEntity tower = GameFactory.Tower_Create(ctx.templateContext, ctx.idService, typeID, pos);
            ctx.towerRepository.Add(tower);
            return tower;
        }

    }

}