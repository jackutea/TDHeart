using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class PropRepository {

        Dictionary<int, PropEntity> all;

        PropEntity[] tempArray;

        public PropRepository() {
            all = new Dictionary<int, PropEntity>();
            tempArray = new PropEntity[GameConst.CELL_X_COUNT * GameConst.CELL_Y_COUNT];
        }

        public void Add(PropEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out PropEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public bool TryGetNearest(Vector3 pos, AllyFlag allyFlag, float range, out PropEntity result) {
            result = null;
            float minDistanceSqr = float.MaxValue;
            float rangeSqr = range * range;
            foreach (var item in all.Values) {
                if (item.allyFlag != allyFlag) {
                    continue;
                }
                float distanceSqr = Vector3.SqrMagnitude(pos - item.lpos);
                if (distanceSqr < minDistanceSqr) {
                    minDistanceSqr = distanceSqr;
                    result = item;
                }
            }
            return result != null && minDistanceSqr <= rangeSqr;
        }

        public PropEntity Find(Predicate<PropEntity> match) {
            foreach (var entity in all.Values) {
                if (match(entity)) {
                    return entity;
                }
            }
            return null;
        }

        public void Remove(PropEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out PropEntity[] result) {
            if (all.Count >= tempArray.Length) {
                tempArray = new PropEntity[tempArray.Length + 20];
            }
            int count = all.Count;
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }

}