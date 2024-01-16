using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class ClientMain : MonoBehaviour {

        [SerializeField] Canvas panelCanvas;
        [SerializeField] Canvas hudCanvas;

        MainContext mainContext;

        bool isTearDown = false;

        float restTime;

        void Awake() {

            mainContext = new MainContext(panelCanvas, hudCanvas);

            TemplateInfra.LoadAll(mainContext.templateContext);

            Binding();

            LoginBusiness.Enter(mainContext.loginContext);

        }

        void Binding() {

            // ==== UI Events ====
            var uiEvents = mainContext.uiContext.events;

            // - Login
            uiEvents.P_Login_OnClickStartHandle += () => {
                LoginBusiness.Exit(mainContext.loginContext);
                GameBusiness.Enter(mainContext.gameContext);
            };

            // - Failed
            uiEvents.P_Failed_OnRestartHandle += () => {
                UIApp.P_Failed_Close(mainContext.uiContext);
                GameBusiness.Exit(mainContext.gameContext);
                GameBusiness.Enter(mainContext.gameContext);
            };

            uiEvents.P_Failed_OnExitHandle += () => {
                UIApp.P_Failed_Close(mainContext.uiContext);
                LoginBusiness.Enter(mainContext.loginContext);
            };

        }

        void Update() {

            float dt = Time.deltaTime;
            GameBusiness.PreTick(mainContext.gameContext, dt);

            restTime += dt;
            float fixedInterval = GameConst.FIXED_INTERVAL;
            if (restTime <= fixedInterval) {
                GameBusiness.FixedTick(mainContext.gameContext, restTime);
                restTime = 0;
            } else {
                while (restTime > fixedInterval) {
                    GameBusiness.FixedTick(mainContext.gameContext, fixedInterval);
                    restTime -= fixedInterval;
                }
            }

            GameBusiness.PostTick(mainContext.gameContext, dt);

        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
            TemplateInfra.UnloadAll(mainContext.templateContext);
        }

    }

}
