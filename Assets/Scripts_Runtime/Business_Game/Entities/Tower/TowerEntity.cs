using System;
using UnityEngine;

namespace TDHeart {

    public class TowerEntity : MonoBehaviour {

        public int id;
        public AllyFlag allyFlag;

        public Vector3Int lpos;

        // Spawner
        public TowerSpawnerModel spawnerModel;

        public void Ctor() {
            spawnerModel = new TowerSpawnerModel();
        }

        public void Init() {
            spawnerModel.Fake();
        }

        public void Pos_Set(Vector3Int pos) {
            transform.position = pos;
            lpos = pos;
        }

    }

}