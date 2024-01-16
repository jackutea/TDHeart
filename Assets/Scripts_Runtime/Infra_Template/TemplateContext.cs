using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TDHeart {

    public class TemplateContext  {

        Dictionary<string, GameObject> entities;
        public AsyncOperationHandle entitiesOp;

        Dictionary<int, RoleTM> roleTMs;
        public AsyncOperationHandle roleTMsOp;

        public TemplateContext() {
            entities = new Dictionary<string, GameObject>();
            roleTMs = new Dictionary<int, RoleTM>(100);
        }

        public void Entity_Add(string name, GameObject entity) {
            entities.Add(name, entity);
        }

        public GameObject Entity_GetTower() {
            return entities["Entity_Tower"];
        }

        public GameObject Entity_GetRole() {
            return entities["Entity_Role"];
        }

        // Role
        public void Role_Add(RoleTM tm) {
            roleTMs.Add(tm.typeID, tm);
        }

        public RoleTM Role_Get(int typeID) {
            return roleTMs[typeID];
        }

    }

}