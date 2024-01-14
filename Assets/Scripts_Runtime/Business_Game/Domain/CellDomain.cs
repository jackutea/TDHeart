using UnityEngine;

namespace TDHeart {

    public static class CellDomain {

        public static CellEntity Spawn(GameContext ctx, int typeID, Vector3Int pos) {
            CellEntity cell = GameFactory.Cell_Create(ctx.idService, typeID, pos);
            ctx.cellRepository.Add(cell);
            return cell;
        }

    }

}