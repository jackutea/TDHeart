using UnityEngine;

namespace TDHeart {

    public static class UIApp {

        // P Login
        public static void P_Login_Open(UIContext ctx) {
            var panel = ctx.panel_login;
            if (panel == null) {
                ctx.templateContext.Panel_TryGet(nameof(Panel_Login), out var prefab);
                panel = GameObject.Instantiate(prefab, ctx.panelCanvas.transform).GetComponent<Panel_Login>();
                panel.Ctor();
                panel.OnStartBtnClickHandle = () => {
                    ctx.events.P_Login_OnClickStart();
                };
                ctx.panel_login = panel;
            }
        }

        public static void P_Login_Close(UIContext ctx) {
            var panel = ctx.panel_login;
            panel?.Close();
        }

        // P HeartInfo
        public static void P_HeartInfo_Open(UIContext ctx) {
            var panel = ctx.panel_heartInfo;
            if (panel == null) {
                ctx.templateContext.Panel_TryGet(nameof(Panel_HeartInfo), out var prefab);
                panel = GameObject.Instantiate(prefab, ctx.panelCanvas.transform).GetComponent<Panel_HeartInfo>();
                panel.Ctor();
                ctx.panel_heartInfo = panel;
            }
        }

        public static void P_HeartInfo_SetHeart(UIContext ctx, int count) {
            var panel = ctx.panel_heartInfo;
            panel?.SetHeart(count);
        }

        public static void P_HeartInfo_Close(UIContext ctx) {
            var panel = ctx.panel_heartInfo;
            panel?.Close();
        }

    }

}