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
            if (spawner.waves == null || spawner.waves.Length == 0) {
                return;
            }

            int waveNumber = spawner.waveNumber;
            TowerWaveModel[] waves = spawner.waves;
            if (waveNumber >= waves.Length) {
                return;
            }

            int doneWaveCount = 0;
            int waveNumberWaveCount = 0;
            for (int i = 0; i < waves.Length; i++) {
                ref TowerWaveModel wave = ref waves[i];
                if (wave.waveNumber == waveNumber) {
                    Spawner_ByWave(ctx, tower, ref wave, fixdt);
                    waveNumberWaveCount++;
                    if (wave.count >= wave.countMax) {
                        doneWaveCount++;
                    }
                }
            }

            if (waveNumberWaveCount == doneWaveCount) {
                spawner.waveNumber++;
            }

        }

        static void Spawner_ByWave(GameContext ctx, TowerEntity tower, ref TowerWaveModel wave, float fixdt) {

            if (wave.count >= wave.countMax) {
                return;
            }

            wave.cd -= fixdt;
            if (wave.cd > 0) {
                return;
            }

            wave.intervalTimer -= fixdt;
            if (wave.intervalTimer <= 0) {
                wave.intervalTimer = wave.interval;
                var spawnedRole = RoleDomain.SpawnByTower(ctx, tower, wave.typeID);
                spawnedRole.belongTowerID = tower.id;
                tower.spawnerModel.spawnedEnemyIDs.Add(spawnedRole.id);
                wave.count++;
            }

            wave.maintainTimer -= fixdt;
            if (wave.maintainTimer <= 0) {
                wave.maintainTimer = wave.maintain;
                wave.cd = wave.cdMax;
                return;
            }

        }

    }

}