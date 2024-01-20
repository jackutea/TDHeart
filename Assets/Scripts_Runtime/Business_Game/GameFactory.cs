using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

        public static PlayerEntity Player_Create(TemplateContext templateContext, IDService idService, int typeID) {
            PlayerEntity player = new PlayerEntity();
            player.hp = 6;
            player.hpMax = 6;
            return player;
        }

        public static CellEntity Cell_Create(TemplateContext templateContext, IDService idService, int typeID, Vector3Int pos) {
            bool has = templateContext.Entity_TryGetCell(out GameObject prefab);
            if (!has) {
                Debug.LogError("Cell prefab not found");
            }
            CellEntity cell = GameObject.Instantiate(prefab).GetComponent<CellEntity>();
            cell.id = idService.cellID++;
            cell.Pos_Set(pos);
            return cell;
        }

        public static TowerEntity Tower_Create(TemplateContext templateContext, IDService idService, int typeID, AllyFlag allyFlag, Vector3Int pos) {
            bool has = templateContext.Entity_TryGetTower(out GameObject prefab);
            if (!has) {
                Debug.LogError("Tower prefab not found");
            }
            TowerSO tm = templateContext.Tower_Get(typeID);
            TowerEntity tower = GameObject.Instantiate(prefab).GetComponent<TowerEntity>();
            GameObject mod = GameObject.Instantiate(tm.modPrefab, tower.transform);
            tower.Ctor(mod);
            tower.id = idService.towerID++;
            tower.allyFlag = allyFlag;
            tower.Pos_Set(pos);

            // Spawner
            var spawnerTM = tm.spawnerTM;
            var spawnerModel = tower.spawnerModel;
            if (spawnerTM != null && spawnerTM.isSpawner) {
                spawnerModel.waves = new TowerWaveModel[spawnerTM.waves.Length];
                for (int i = 0; i < spawnerTM.waves.Length; i += 1) {
                    TowerWaveTM waveTM = spawnerTM.waves[i];
                    TowerWaveModel waveModel = new TowerWaveModel();
                    waveModel.waveNumber = waveTM.waveNumber;
                    waveModel.cd = waveTM.cd;
                    waveModel.cdMax = waveTM.cd;
                    waveModel.maintain = waveTM.maintain;
                    waveModel.maintainTimer = waveTM.maintain;
                    waveModel.interval = waveTM.interval;
                    waveModel.intervalTimer = waveTM.interval;
                    waveModel.typeID = waveTM.typeID;
                    waveModel.count = 0;
                    waveModel.countMax = waveTM.count;
                    spawnerModel.waves[i] = waveModel;
                }
                spawnerModel.waveNumber = 0;
                spawnerModel.path = spawnerTM.path;
            }

            // Cast
            var castModel = tower.castModel;
            var skills = tm.skills;
            if (skills != null && skills.Length > 0) {
                for (int i = 0; i < skills.Length; i += 1) {
                    SkillSO skillSO = skills[i];
                    SkillSubEntity skill = new SkillSubEntity();
                    skill.typeID = skillSO.typeID;
                    skill.typeName = skillSO.typeName;

                    skill.autoCastType = skillSO.autoCastType;
                    skill.castAimType = skillSO.castAimType;
                    skill.castTargetEntityFlag = skillSO.castTargetEntityFlag;
                    skill.castRange = skillSO.castRange;
                    skill.cd = skillSO.cd;
                    skill.cdMax = skillSO.cd;
                    skill.maintain = skillSO.maintain;
                    skill.maintainTimer = skillSO.maintain;
                    skill.interval = skillSO.interval;
                    skill.intervalTimer = skillSO.interval;

                    skill.hasSpawnBullet = skillSO.hasSpawnBullet;
                    skill.spawnBulletTypeID = skillSO.spawnBulletTypeID;
                    castModel.skills.Add(skill);
                }
            }

            return tower;
        }

        public static RoleEntity Role_Create(TemplateContext templateContext, IDService idService, int typeID, AllyFlag allyFlag, Vector3 pos) {
            bool has = templateContext.Entity_TryGetRole(out GameObject prefab);
            if (!has) {
                Debug.LogError("Tower prefab not found");
            }
            RoleSO tm = templateContext.Role_Get(typeID);
            RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            GameObject mod = GameObject.Instantiate(tm.modPrefab, role.transform);
            role.Ctor(mod);
            role.id = idService.roleID++;
            role.allyFlag = allyFlag;
            role.Pos_Set(pos);

            role.hp = 2;
            role.hpMax = 2;
            return role;
        }

        public static PropEntity Prop_Create(TemplateContext templateContext, IDService idService, int typeID, AllyFlag allyFlag, Vector3 pos) {
            bool has = templateContext.Entity_TryGetProp(out GameObject prefab);
            if (!has) {
                Debug.LogError("Prop prefab not found");
            }
            PropSO tm = templateContext.Prop_Get(typeID);
            PropEntity prop = GameObject.Instantiate(prefab).GetComponent<PropEntity>();
            GameObject mod = GameObject.Instantiate(tm.modPrefab, prop.transform);
            prop.Ctor(mod);
            prop.id = idService.propID++;
            prop.allyFlag = allyFlag;
            prop.Pos_Set(pos);
            return prop;
        }

        public static BulletEntity Bullet_Create(TemplateContext templateContext, IDService idService, int typeID, AllyFlag allyFlag, Vector3 pos) {
            bool has = templateContext.Entity_TryGetBullet(out GameObject prefab);
            if (!has) {
                Debug.LogError("Bullet prefab not found");
            }
            BulletSO tm = templateContext.Bullet_Get(typeID);
            BulletEntity bullet = GameObject.Instantiate(prefab).GetComponent<BulletEntity>();
            GameObject mod = GameObject.Instantiate(tm.modPrefab, bullet.transform);
            bullet.Ctor(mod);
            bullet.id = idService.bulletID++;
            bullet.allyFlag = allyFlag;
            bullet.Pos_Set(pos);
            return bullet;
        }

    }

}