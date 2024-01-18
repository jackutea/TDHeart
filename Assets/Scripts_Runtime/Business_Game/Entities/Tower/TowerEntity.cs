using System;
using UnityEngine;

namespace TDHeart {

    public class TowerEntity : MonoBehaviour {

        public int id;
        public readonly EntityFlag entityType = EntityFlag.Tower;
        public AllyFlag allyFlag;

        public Vector3Int lpos;

        // Spawner
        public TowerSpawnerModel spawnerModel;

        // Cast
        public TowerCastModel castModel;

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
            spawnerModel = new TowerSpawnerModel();
            castModel = new TowerCastModel();
        }

        public void Init() {
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