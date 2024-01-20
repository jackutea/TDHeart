using UnityEngine;
using UnityEngine.UI;

namespace TDHeart.UI {

    public class HUD_HpBar : MonoBehaviour {

        public I32I32_U64 onlyID;
        [SerializeField] RectTransform barRect;
        [SerializeField] Image imgBar;

        public void Ctor(I32I32_U64 onlyID) {
            this.onlyID = onlyID;
        }

        public void Init(Vector3 pos, Vector3 cameraPos, float width, float hp, float hpMax) {
            transform.position = pos;
            transform.LookAt(cameraPos);
            SetWidth(width);
            SetHp(hp, hpMax);
        }

        public void Close() {
            GameObject.Destroy(gameObject);
        }

        public void SetWidth(float width) {
            var rect = barRect.rect;
            barRect.sizeDelta = new Vector2(width, rect.height);
        }

        public void SetHp(float hp, float hpMax) {
            if (hpMax == 0) {
                imgBar.fillAmount = 0;
                return;
            }
            imgBar.fillAmount = hp / hpMax;
        }

    }

}