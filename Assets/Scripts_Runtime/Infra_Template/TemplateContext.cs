using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TDHeart {

    public class TemplateContext  {

        Dictionary<string, GameObject> entities;

        public TemplateContext() {
            entities = new Dictionary<string, GameObject>();
        }

        public void Entity_Add(string name, GameObject entity) {
            entities.Add(name, entity);
        }

        public GameObject Entity_GetTower() {
            return entities["Entity_Tower"];
        }

        bool Entity_TryGet(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }

    }

}