using System;
using System.Linq;
using System.Collections.Generic;

namespace TDHeart {

    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        RoleEntity[] tempArray;

        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
            tempArray = new RoleEntity[GameConst.CELL_X_COUNT * GameConst.CELL_Y_COUNT];
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out RoleEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Remove(RoleEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out RoleEntity[] result) {
            if (all.Count >= tempArray.Length) {
                tempArray = new RoleEntity[tempArray.Length + 20];
            }
            int count = all.Count;
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }

}