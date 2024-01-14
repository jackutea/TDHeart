using UnityEngine;

namespace TDHeart {

    public static class GameFactory {

        public static CellEntity Cell_Create(IDService idService, int typeID, Vector2Int pos) {
            CellEntity cell = new CellEntity();
            cell.id = idService.cellID++;
            cell.pos = pos;
            return cell;
        }

    }

}