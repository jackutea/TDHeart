using UnityEngine;
using TDHeart.UI;

namespace TDHeart {

    public static class UIApp {

        // P Login
        public static void P_Login_Open(UIContext ctx) {
            var panel = ctx.panel_login;
            if (panel == null) {
                panel = UIFactory.P_Login_Create(ctx);
                panel.Ctor();
                ctx.panel_login = panel;

                panel.OnStartBtnClickHandle = () => {
                    ctx.events.P_Login_OnClickStart();
                };
            }
            panel.Show();
        }

        public static void P_Login_Close(UIContext ctx) {
            var panel = ctx.panel_login;
            panel?.Close();
        }

        // P HeartInfo
        public static void P_HeartInfo_Open(UIContext ctx) {
            var panel = ctx.panel_heartInfo;
            if (panel == null) {
                panel = UIFactory.P_HeartInfo_Create(ctx);
                panel.Ctor();
                ctx.panel_heartInfo = panel;
            }
            panel.Show();
        }

        public static void P_HeartInfo_SetHeart(UIContext ctx, int count) {
            var panel = ctx.panel_heartInfo;
            panel?.SetHeart(count);
        }

        public static void P_HeartInfo_Close(UIContext ctx) {
            var panel = ctx.panel_heartInfo;
            panel?.Close();
        }

        // P Failed
        public static void P_Failed_Open(UIContext ctx) {
            var panel = ctx.panel_failed;
            if (panel == null) {
                panel = UIFactory.P_Failed_Create(ctx);
                panel.Ctor();
                ctx.panel_failed = panel;

                panel.OnRestartHandle = () => {
                    ctx.events.P_Failed_OnRestart();
                };

                panel.OnExitHandle = () => {
                    ctx.events.P_Failed_OnExit();
                };

            }
            panel.Show();
        }

        public static void P_Failed_Close(UIContext ctx) {
            var panel = ctx.panel_failed;
            panel?.Close();
        }

        // P Win
        public static void P_Win_Open(UIContext ctx) {
            var panel = ctx.panel_win;
            if (panel == null) {
                panel = UIFactory.P_Win_Create(ctx);
                panel.Ctor();
                ctx.panel_win = panel;

                panel.OnReturnHandle = () => {
                    ctx.events.P_Win_OnReturn();
                };

            }
            panel.Show();
        }

        public static void P_Win_Close(UIContext ctx) {
            var panel = ctx.panel_win;
            panel?.Close();
        }

    }

}