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
        }

        public static void UnloadAll(TemplateContext ctx) {
            if (ctx.entitiesOp.IsValid()) {
                Addressables.Release(ctx.entitiesOp);
            }
        }

    }

}