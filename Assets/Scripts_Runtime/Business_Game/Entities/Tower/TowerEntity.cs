using System;
using UnityEngine;

namespace TDHeart {

    public class TowerEntity : MonoBehaviour {

        public int id;

        public Vector3Int lpos;

        // Spawner
        public TowerSpawnerModel spawnerModel;

        public void Ctor() {
            spawnerModel = new TowerSpawnerModel();
        }

        public void Init() {
            spawnerModel.Fake();
        }

        public void SetRPos(Vector3Int rpos) {
            transform.position = rpos;
        }

    }

}