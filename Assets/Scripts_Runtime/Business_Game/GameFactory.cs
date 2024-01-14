using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

        public static CellEntity Cell_Create(IDService idService, int typeID, Vector3Int pos) {
            CellEntity cell = new CellEntity();
            cell.id = idService.cellID++;
            cell.lpos = pos;
            return cell;
        }

        public static TowerEntity Tower_Create(TemplateContext templateContext, IDService idService, int typeID, Vector3Int pos) {
            GameObject prefab = templateContext.Entity_GetTower();
            TowerEntity tower = GameObject.Instantiate(prefab).GetComponent<TowerEntity>();
            tower.Ctor();
            tower.id = idService.towerID++;
            tower.lpos = pos;
            tower.SetRPos(pos);
            return tower;
        }

        public static RoleEntity Role_Create(TemplateContext templateContext, IDService idService, int typeID, Vector3 pos) {
            GameObject prefab = templateContext.Entity_GetRole();
            RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            role.id = idService.roleID++;
            role.lpos = pos;
            role.SetRPos(pos);
            return role;
        }

    }

}