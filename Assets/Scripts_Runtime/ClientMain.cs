using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class ClientMain : MonoBehaviour {

        MainContext mainContext;

        bool isTearDown = false;

        float restTime;

        void Awake() {

            mainContext = new MainContext();

            TemplateInfra.LoadAll(mainContext.templateContext);

            GameBusiness.Enter(mainContext.gameContext);

        }

        void Update() {

            float dt = Time.deltaTime;
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
