using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TDHeart {

    public static class TemplateInfra {

        public static void LoadAll(TemplateContext ctx) {
            {
                const string label = "Entities";
                var op = Addressables.LoadAssetsAsync<GameObject>(label, null);
                var list = op.WaitForCompletion();
                foreach (var obj in list) {
                    ctx.Entity_Add(obj.name, obj);
                }
                ctx.entitiesOp = op;
            }
            {
                const string label = "TM_Role";
                var op = Addressables.LoadAssetsAsync<RoleTM>(label, null);
                var list = op.WaitForCompletion();
                foreach (var tm in list) {
                    ctx.Role_Add(tm);
                }
                ctx.roleTMsOp = op;
            }
        }

        public static void UnloadAll(TemplateContext ctx) {
            if (ctx.entitiesOp.IsValid()) {
                Addressables.Release(ctx.entitiesOp);
            }
            if (ctx.roleTMsOp.IsValid()) {
                Addressables.Release(ctx.roleTMsOp);
            }
        }

    }

}