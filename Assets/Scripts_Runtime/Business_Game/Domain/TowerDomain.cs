using UnityEngine;

namespace TDHeart {

    public static class TowerDomain {

        public static TowerEntity Spawn(GameContext ctx, int typeID, Vector3Int pos, AllyFlag allyFlag) {
            TowerEntity tower = GameFactory.Tower_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, pos);
            tower.Init();
            ctx.towerRepository.Add(tower);
            return tower;
        }

        public static void Spawner_TrySpawn(GameContext ctx, TowerEntity tower, float fixdt) {
            var spawner = tower.spawnerModel;
            if (!spawner.isEnable) {
                return;
            }

            spawner.cd -= fixdt;
            if (spawner.cd > 0) {
                return;
            }

            spawner.maintainTimer -= fixdt;
            if (spawner.maintainTimer <= 0) {
                spawner.maintainTimer = spawner.maintain;
                spawner.cd = spawner.cdMax;
                return;
            }

            spawner.intervalTimer -= fixdt;
            if (spawner.intervalTimer <= 0) {
                spawner.intervalTimer = spawner.interval;
                RoleDomain.SpawnByTower(ctx, tower, spawner.typeID);
            }

        }

    }

}