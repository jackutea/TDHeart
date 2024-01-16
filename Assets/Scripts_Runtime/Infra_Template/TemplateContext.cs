using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TDHeart {

    public class TemplateContext  {

        Dictionary<string, GameObject> entities;
        public AsyncOperationHandle entitiesOp;

        Dictionary<string, GameObject> panels;
        public AsyncOperationHandle panelsOp;

        Dictionary<string, GameObject> huds;
        public AsyncOperationHandle hudsOp;

        Dictionary<int, RoleTM> roleTMs;
        public AsyncOperationHandle roleTMsOp;

        public TemplateContext() {
            entities = new Dictionary<string, GameObject>();
            panels = new Dictionary<string, GameObject>();
            huds = new Dictionary<string, GameObject>();
            roleTMs = new Dictionary<int, RoleTM>(100);
        }

        // Entity
        public void Entity_Add(string name, GameObject entity) {
            entities.Add(name, entity);
        }

        public bool Entity_TryGetTower(out GameObject go) {
            return entities.TryGetValue("Entity_Tower", out go);
        }

        public bool Entity_TryGetRole(out GameObject go) {
            return entities.TryGetValue("Entity_Role", out go);
        }

        // Panel
        public void Panel_Add(string name, GameObject panel) {
            panels.Add(name, panel);
        }

        public bool Panel_TryGet(string name, out GameObject go) {
            return panels.TryGetValue(name, out go);
        }

        // HUD
        public void HUD_Add(string name, GameObject hud) {
            huds.Add(name, hud);
        }

        public bool HUD_TryGet(string name, out GameObject go) {
            return huds.TryGetValue(name, out go);
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