using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDHeart.UI {

    public class Panel_Win : MonoBehaviour {

        [SerializeField] Button btnReturn;

        public Action OnReturnHandle;

        public void Ctor() {
            btnReturn.onClick.AddListener(() => {
                OnReturnHandle?.Invoke();
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