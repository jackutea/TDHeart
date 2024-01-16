using UnityEngine;
using UnityEngine.UI;

namespace TDHeart.UI {

    public class HUD_HpBar : MonoBehaviour {

        [SerializeField] Image imgBar;

        public void SetWidth(float width) {
            var rect = imgBar.rectTransform;
            rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
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