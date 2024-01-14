using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class ClientMain : MonoBehaviour {

        MainContext mainContext;

        void Awake() {
            mainContext = new MainContext();

            TemplateInfra.LoadAll(mainContext.templateContext);
            Debug.Log("Hello");

            GameBusiness.Enter(mainContext.gameContext);
        }

        void Update() {
            float dt = Time.deltaTime;
            GameBusiness.Tick(mainContext.gameContext, dt);
        }

    }

}
