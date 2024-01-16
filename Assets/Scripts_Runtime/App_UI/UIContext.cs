using System.Collections.Generic;
using UnityEngine;

namespace TDHeart {

    public class UIContext {

        Dictionary<I32I32_U64, HUD_HpBar> hpBarDict;
        public Panel_Login panel_login;

        public UIEvents events;

        public Canvas panelCanvas;
        public Canvas hudCanvas;

        public TemplateContext templateContext;

        public UIContext() {
            events = new UIEvents();
            hpBarDict = new Dictionary<I32I32_U64, HUD_HpBar>();
        }

        public void Inject(Canvas panelCanvas, Canvas hudCanvas, TemplateContext templateContext) {
            this.panelCanvas = panelCanvas;
            this.hudCanvas = hudCanvas;
            this.templateContext = templateContext;
        }

        public void HpBar_Add(I32I32_U64 key, HUD_HpBar hpBar) {
            hpBarDict.Add(key, hpBar);
        }

        public bool HpBar_TryGet(I32I32_U64 key, out HUD_HpBar hpBar) {
            return hpBarDict.TryGetValue(key, out hpBar);
        }

        public void HpBar_Remove(I32I32_U64 key) {
            hpBarDict.Remove(key);
        }

    }

}