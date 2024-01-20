using UnityEngine;

namespace TDHeart.UI {

    public static class UIFactory {

        public static Panel_Login P_Login_Create(UIContext ctx) {
            return PCreate<Panel_Login>(ctx);
        }

        public static Panel_HeartInfo P_HeartInfo_Create(UIContext ctx) {
            return PCreate<Panel_HeartInfo>(ctx);
        }

        public static Panel_Failed P_Failed_Create(UIContext ctx) {
            return PCreate<Panel_Failed>(ctx);
        }

        public static Panel_Win P_Win_Create(UIContext ctx) {
            return PCreate<Panel_Win>(ctx);
        }

        public static HUD_HpBar H_HpBar_Create(UIContext ctx) {
            return HCreate<HUD_HpBar>(ctx);
        }

        static T PCreate<T>(UIContext ctx) where T : MonoBehaviour {
            ctx.templateContext.Panel_TryGet(typeof(T).Name, out var prefab);
            var panel = GameObject.Instantiate(prefab, ctx.panelCanvas.transform).GetComponent<T>();
            return panel;
        }

        static T HCreate<T>(UIContext ctx) where T : MonoBehaviour {
            ctx.templateContext.HUD_TryGet(typeof(T).Name, out var prefab);
            var panel = GameObject.Instantiate(prefab).GetComponent<T>();
            return panel;
        }

    }

}