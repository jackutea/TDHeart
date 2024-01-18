using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class BulletRepository {

        Dictionary<int, BulletEntity> all;

        BulletEntity[] tempArray;

        public BulletRepository() {
            all = new Dictionary<int, BulletEntity>();
            tempArray = new BulletEntity[GameConst.CELL_X_COUNT * GameConst.CELL_Y_COUNT];
        }

        public void Add(BulletEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out BulletEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public bool TryGetNearest(Vector3 pos, AllyFlag allyFlag, float range, out BulletEntity result) {
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

        public void Remove(BulletEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out BulletEntity[] result) {
            if (all.Count >= tempArray.Length) {
                tempArray = new BulletEntity[tempArray.Length + 20];
            }
            int count = all.Count;
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }

}