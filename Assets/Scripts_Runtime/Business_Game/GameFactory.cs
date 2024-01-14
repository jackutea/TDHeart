using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

        public static CellEntity Cell_Create(IDService idService, int typeID, Vector2Int pos) {
            CellEntity cell = new CellEntity();
            cell.id = idService.cellID++;
            cell.pos = pos;
            return cell;
        }

        public static TowerEntity Tower_Create(TemplateContext templateContext, IDService idService, int typeID, Vector3Int pos) {
            GameObject prefab = templateContext.Entity_GetTower();
            TowerEntity tower = GameObject.Instantiate(prefab).GetComponent<TowerEntity>();
            tower.id = idService.towerID++;
            tower.lpos = pos;
            tower.SetRPos(pos);
            return tower;
        }

    }

}