using System.Collections.Generic;
using UnityEngine;
using TDHeart.UI;

namespace TDHeart {

    public class UIContext {

        Dictionary<I32I32_U64, HUD_HpBar> hud_hpBars;

        public Panel_Login panel_login;
        public Panel_HeartInfo panel_heartInfo;
        public Panel_Failed panel_failed;

        public UIEvents events;

        public Canvas panelCanvas;
        public Canvas hudCanvas;

        public TemplateContext templateContext;

        public UIContext() {
            events = new UIEvents();
            hud_hpBars = new Dictionary<I32I32_U64, HUD_HpBar>();
        }

        public void Inject(Canvas panelCanvas, Canvas hudCanvas, TemplateContext templateContext) {
            this.panelCanvas = panelCanvas;
            this.hudCanvas = hudCanvas;
            this.templateContext = templateContext;
        }

        public void H_HpBar_Add(I32I32_U64 key, HUD_HpBar hpBar) {
            hud_hpBars.Add(key, hpBar);
        }

        public bool H_HpBar_TryGet(I32I32_U64 key, out HUD_HpBar hpBar) {
            return hud_hpBars.TryGetValue(key, out hpBar);
        }

        public void H_HpBar_Remove(I32I32_U64 key) {
            hud_hpBars.Remove(key);
        }

    }

}