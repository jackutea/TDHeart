using System;
using UnityEngine;

namespace TDHeart {

    public class TowerEntity : MonoBehaviour {

        public int id;
        public AllyFlag allyFlag;

        public Vector3Int lpos;

        // Spawner
        public TowerSpawnerModel spawnerModel;

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
            spawnerModel = new TowerSpawnerModel();
        }

        public void Init() {
            spawnerModel.Fake();
        }

        public void TearDown() {
            GameObject.Destroy(mod);
            GameObject.Destroy(gameObject);
        }

        public void Pos_Set(Vector3Int pos) {
            transform.position = pos;
            lpos = pos;
        }

    }

}