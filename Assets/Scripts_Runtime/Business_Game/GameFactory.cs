using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

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
            TowerEntity tower = GameObject.Instantiate(prefab).GetComponent<TowerEntity>();
            tower.Ctor();
            tower.id = idService.towerID++;
            tower.allyFlag = allyFlag;
            tower.lpos = pos;
            tower.SetRPos(pos);
            return tower;
        }

        public static RoleEntity Role_Create(TemplateContext templateContext, IDService idService, int typeID, AllyFlag allyFlag, Vector3 pos) {
            bool has = templateContext.Entity_TryGetRole(out GameObject prefab);
            if (!has) {
                Debug.LogError("Tower prefab not found");
            }
            RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            RoleTM tm = templateContext.Role_Get(typeID);
            GameObject mod = GameObject.Instantiate(tm.modPrefab, role.transform);
            role.Ctor(mod);
            role.id = idService.roleID++;
            role.allyFlag = allyFlag;
            role.lpos = pos;
            role.SetRPos(pos);

            role.hp = 10;
            role.hpMax = 10;
            return role;
        }

    }

}