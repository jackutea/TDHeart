using System;
using System.Linq;
using System.Collections.Generic;

namespace TDHeart {

    public class CellRepository {

        Dictionary<int, CellEntity> all;

        CellEntity[] tempArray;

        public CellRepository() {
            all = new Dictionary<int, CellEntity>();
            tempArray = new CellEntity[GameConst.CELL_X_COUNT * GameConst.CELL_Y_COUNT];
        }

        public void Add(CellEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out CellEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Remove(CellEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out CellEntity[] result) {
            if (all.Count >= tempArray.Length) {
                tempArray = new CellEntity[tempArray.Length + 20];
            }
            int count = all.Count;
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }

}