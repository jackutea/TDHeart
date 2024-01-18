using UnityEngine;

namespace TDHeart {

    public static class TowerDomain {

        public static TowerEntity Spawn(GameContext ctx, int typeID, Vector3Int pos, AllyFlag allyFlag) {
            TowerEntity tower = GameFactory.Tower_Create(ctx.templateContext, ctx.idService, typeID, allyFlag, pos);
            tower.Init();
            ctx.towerRepository.Add(tower);
            return tower;
        }

        // Spawn
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
                    Spawner_SpawnByWave(ctx, tower, ref wave, fixdt);
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

        static void Spawner_SpawnByWave(GameContext ctx, TowerEntity tower, ref TowerWaveModel wave, float fixdt) {

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

        // Cast
        public static void Cast_TryCast(GameContext ctx, TowerEntity tower, float fixdt) {

            var castModel = tower.castModel;
            if (castModel.skills == null || castModel.skills.Count == 0) {
                return;
            }

            for (int i = 0; i < castModel.skills.Count; i += 1) {
                var skill = castModel.skills[i];
                Cast_TryCastOneSkill(ctx, tower, skill, fixdt);
            }

        }

        static void Cast_TryCastOneSkill(GameContext ctx, TowerEntity tower, SkillSubEntity skill, float fixdt) {
            skill.cd -= fixdt;
            if (skill.cd > 0) {
                return;
            }

            skill.intervalTimer -= fixdt;
            if (skill.intervalTimer <= 0) {
                skill.intervalTimer = skill.interval;
                Cast_CastSkill(ctx, tower, skill, fixdt);
            }

            skill.maintainTimer -= fixdt;
            if (skill.maintainTimer <= 0) {
                skill.maintainTimer = skill.maintain;
                skill.cd = skill.cdMax;
                return;
            }

        }

        static void Cast_CastSkill(GameContext ctx, TowerEntity tower, SkillSubEntity skill, float fixdt) {

            if (skill.hasSpawnBullet) {
                if (skill.autoCastType == SkillAutoCastType.NeedTarget) {
                    var bullet = BulletDomain.Spawn(ctx, skill.spawnBulletTypeID, tower.allyFlag, tower.lpos);
                } else if (skill.autoCastType == SkillAutoCastType.FreeTarget) {
                    var bullet = BulletDomain.Spawn(ctx, skill.spawnBulletTypeID, tower.allyFlag, tower.lpos);
                } else {
                    Debug.LogError("SkillAutoCastType not found");
                }
            }

        }

    }

}