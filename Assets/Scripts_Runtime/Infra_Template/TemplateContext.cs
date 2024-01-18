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

        Dictionary<int, RoleSO> roleTMs;
        public AsyncOperationHandle roleTMsOp;

        Dictionary<int, TowerSO> towerTMs;
        public AsyncOperationHandle towerTMsOp;

        Dictionary<int, PropSO> propTMs;
        public AsyncOperationHandle propTMsOp;

        Dictionary<int, BulletSO> bulletTMs;
        public AsyncOperationHandle bulletTMsOp;

        public TemplateContext() {
            entities = new Dictionary<string, GameObject>();
            panels = new Dictionary<string, GameObject>();
            huds = new Dictionary<string, GameObject>();
            roleTMs = new Dictionary<int, RoleSO>(100);
            towerTMs = new Dictionary<int, TowerSO>(100);
            propTMs = new Dictionary<int, PropSO>(100);
            bulletTMs = new Dictionary<int, BulletSO>(100);
        }

        // Entity
        public void Entity_Add(string name, GameObject entity) {
            entities.Add(name, entity);
        }

        public bool Entity_TryGetTower(out GameObject go) {
            return entities.TryGetValue("Entity_Tower", out go);
        }

        public bool Entity_TryGetCell(out GameObject go) {
            return entities.TryGetValue("Entity_Cell", out go);
        }

        public bool Entity_TryGetRole(out GameObject go) {
            return entities.TryGetValue("Entity_Role", out go);
        }

        public bool Entity_TryGetProp(out GameObject go) {
            return entities.TryGetValue("Entity_Prop", out go);
        }

        public bool Entity_TryGetBullet(out GameObject go) {
            return entities.TryGetValue("Entity_Bullet", out go);
        }

        // UI Panel
        public void Panel_Add(string name, GameObject panel) {
            panels.Add(name, panel);
        }

        public bool Panel_TryGet(string name, out GameObject go) {
            return panels.TryGetValue(name, out go);
        }

        // UI HUD
        public void HUD_Add(string name, GameObject hud) {
            huds.Add(name, hud);
        }

        public bool HUD_TryGet(string name, out GameObject go) {
            return huds.TryGetValue(name, out go);
        }

        // TM Role
        public void Role_Add(RoleSO tm) {
            roleTMs.Add(tm.typeID, tm);
        }

        public RoleSO Role_Get(int typeID) {
            return roleTMs[typeID];
        }

        // TM Tower
        public void Tower_Add(TowerSO tm) {
            towerTMs.Add(tm.typeID, tm);
        }

        public TowerSO Tower_Get(int typeID) {
            return towerTMs[typeID];
        }

        // TM Prop
        public void Prop_Add(PropSO tm) {
            propTMs.Add(tm.typeID, tm);
        }

        public PropSO Prop_Get(int typeID) {
            return propTMs[typeID];
        }

        // TM Bullet
        public void Bullet_Add(BulletSO tm) {
            bulletTMs.Add(tm.typeID, tm);
        }

        public BulletSO Bullet_Get(int typeID) {
            return bulletTMs[typeID];
        }

    }

}