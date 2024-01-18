using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class TowerRepository {

        Dictionary<int, TowerEntity> all;

        TowerEntity[] tempArray;

        public TowerRepository() {
            all = new Dictionary<int, TowerEntity>();
            tempArray = new TowerEntity[GameConst.CELL_X_COUNT * GameConst.CELL_Y_COUNT];
        }

        public void Add(TowerEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out TowerEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Remove(TowerEntity entity) {
            all.Remove(entity.id);
        }

        public bool TryGetNearest(Vector3 pos, AllyFlag allyFlag, float range, out TowerEntity result) {
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

        public int TakeAll(out TowerEntity[] result) {
            if (all.Count >= tempArray.Length) {
                tempArray = new TowerEntity[tempArray.Length + 20];
            }
            int count = all.Count;
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }

}