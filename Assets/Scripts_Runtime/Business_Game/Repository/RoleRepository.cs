using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

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

        public bool TryGetNearest(Vector3 pos, AllyFlag allyFlag, float range, out RoleEntity result) {
            result = null;
            float minDistanceSqr = float.MaxValue;
            float rangeSqr = range * range;
            foreach (var item in all.Values) {
                if (item.allyFlag != allyFlag) {
                    continue;
                }
                float distanceSqr = Vector3.SqrMagnitude(pos - item.lpos);
                if (distanceSqr <= rangeSqr && distanceSqr < minDistanceSqr) {
                    minDistanceSqr = distanceSqr;
                    result = item;
                }
            }
            return result != null;
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