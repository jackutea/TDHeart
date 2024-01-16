using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDHeart.UI {

    public class Panel_Failed : MonoBehaviour {

        [SerializeField] Button btnRestart;
        [SerializeField] Button btnExit;

        public Action OnRestartHandle;
        public Action OnExitHandle;

        public void Ctor() {
            
            btnRestart.onClick.AddListener(() => {
                OnRestartHandle?.Invoke();
            });
            
            btnExit.onClick.AddListener(() => {
                OnExitHandle?.Invoke();
            });

        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Close() {
            gameObject.SetActive(false);
        }

    }

}