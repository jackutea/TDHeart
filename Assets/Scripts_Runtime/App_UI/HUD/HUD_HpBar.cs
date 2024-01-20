using UnityEngine;
using UnityEngine.UI;

namespace TDHeart.UI {

    public class HUD_HpBar : MonoBehaviour {

        public I32I32_U64 onlyID;
        [SerializeField] Image imgBg;
        [SerializeField] Image imgBar;

        public void Ctor(I32I32_U64 onlyID) {
            this.onlyID = onlyID;
        }

        public void Init(Vector3 pos, Vector3 cameraPos, float width, float hp, float hpMax) {
            transform.position = pos;
            transform.forward = (pos - cameraPos).normalized;
            SetWidth(width);
            SetHp(hp, hpMax);
        }

        public void Close() {
            GameObject.Destroy(gameObject);
        }

        public void SetWidth(float width) {
            var barRect = imgBar.rectTransform;
            var bgRect = imgBg.rectTransform;
            bgRect.sizeDelta = new Vector2(width, bgRect.sizeDelta.y);
            barRect.sizeDelta = new Vector2(width, barRect.sizeDelta.y);
        }

        public void SetHp(float hp, float hpMax) {
            var barRect = imgBar.rectTransform;
            var bgRect = imgBg.rectTransform;
            if (hpMax == 0) {
                barRect.sizeDelta = new Vector2(0, barRect.sizeDelta.y);
                return;
            }
            float percent = hp / hpMax;
            barRect.sizeDelta = new Vector2(bgRect.sizeDelta.x * percent, barRect.sizeDelta.y);
        }

    }

}