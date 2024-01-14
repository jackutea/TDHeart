using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class ClientMain : MonoBehaviour {

        MainContext mainContext;

        void Awake() {
            mainContext = new MainContext();
            Debug.Log("Hello");
        }

        void Update() {
            float dt = Time.deltaTime;
            GameBusiness.Tick(mainContext.gameContext, dt);
        }

    }

}
