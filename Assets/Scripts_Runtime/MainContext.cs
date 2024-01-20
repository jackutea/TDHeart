using UnityEngine;

namespace TDHeart {

    public class MainContext {

        public LoginContext loginContext;
        public GameContext gameContext;

        public UIContext uiContext;

        public TemplateContext templateContext;
        public CameraContext cameraContext;

        public MainContext(Camera mainCamera, Canvas panelCanvas, Canvas hudCanvas) {

            loginContext = new LoginContext();
            gameContext = new GameContext();

            uiContext = new UIContext();

            templateContext = new TemplateContext();
            cameraContext = new CameraContext();

            loginContext.Inject(uiContext);
            gameContext.Inject(uiContext, templateContext, cameraContext);

            uiContext.Inject(panelCanvas, hudCanvas, templateContext);

            cameraContext.Inject(mainCamera);

        }

    }

}