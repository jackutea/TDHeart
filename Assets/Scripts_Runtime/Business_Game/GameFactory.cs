using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

        public static PlayerEntity Player_Create(TemplateContext templateContext, IDService idService, int typeID) {
            PlayerEntity player = new PlayerEntity();
            player.hp = 3;
            player.hpMax = 3;
            return player;
        }

        public static CellEntity Cell_Create(IDService idService, int typeID, Vector3Int pos) {
            CellEntity cell = new CellEntity();
            cell.id = idService.cellID++;
            cell.lpos = pos;
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

            role.hp = 10;
            role.hpMax = 10;
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

    }

}