using UnityEngine;

namespace TDHeart.UI {

    public static class UIFactory {

        public static Panel_Login P_Login_Create(UIContext ctx) {
            return Create<Panel_Login>(ctx);
        }

        public static Panel_HeartInfo P_HeartInfo_Create(UIContext ctx) {
            return Create<Panel_HeartInfo>(ctx);
        }

        public static Panel_Failed P_Failed_Create(UIContext ctx) {
            return Create<Panel_Failed>(ctx);
        }

        public static Panel_Win P_Win_Create(UIContext ctx) {
            return Create<Panel_Win>(ctx);
        }

        static T Create<T>(UIContext ctx) where T : MonoBehaviour {
            ctx.templateContext.Panel_TryGet(typeof(T).Name, out var prefab);
            var panel = GameObject.Instantiate(prefab, ctx.panelCanvas.transform).GetComponent<T>();
            return panel;
        }

    }

}