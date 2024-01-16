using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDHeart {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button startBtn;

        public Action OnStartBtnClickHandle;

        public void Ctor() {
            startBtn.onClick.AddListener(() => {
                OnStartBtnClickHandle?.Invoke();
            });
        }

        public void Close() {
            gameObject.SetActive(false);
        }

    }

}