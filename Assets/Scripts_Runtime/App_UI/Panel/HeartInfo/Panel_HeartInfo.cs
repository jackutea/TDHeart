using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDHeart {

    public class Panel_HeartInfo : MonoBehaviour {

        [SerializeField] Image elePrefab;
        [SerializeField] Transform heartGroup;

        List<Image> hearts;

        public void Ctor() {
            hearts = new List<Image>();
        }

        public void Close() {
            gameObject.SetActive(false);
        }

        public void SetHeart(int count) {
            if (count < 0) {
                count = 0;
            }
            int diff = count - hearts.Count;
            if (diff > 0) {
                for (int i = 0; i < diff; i++) {
                    var heart = GameObject.Instantiate(elePrefab, heartGroup);
                    hearts.Add(heart);
                }
            } else if (diff < 0) {
                for (int i = -diff - 1; i >= 0; i--) {
                    var heart = hearts[hearts.Count - 1];
                    hearts.RemoveAt(hearts.Count - 1);
                    GameObject.Destroy(heart.gameObject);
                }
            } else {
                // do nothing
            }
        }

    }

}