using UnityEngine;

namespace TDHeart {

    public class MainContext {

        public LoginContext loginContext;
        public GameContext gameContext;

        public UIContext uiContext;

        public TemplateContext templateContext;

        public MainContext(Canvas panelCanvas, Canvas hudCanvas) {

            loginContext = new LoginContext();
            gameContext = new GameContext();

            uiContext = new UIContext();

            templateContext = new TemplateContext();

            loginContext.Inject(uiContext);
            gameContext.Inject(uiContext, templateContext);

            uiContext.Inject(panelCanvas, hudCanvas, templateContext);

        }

    }

}