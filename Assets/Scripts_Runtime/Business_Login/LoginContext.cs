namespace TDHeart {

    public class LoginContext {

        public UIContext uiContext;

        public LoginContext() {

        }

        public void Inject(UIContext uiContext) {
            this.uiContext = uiContext;
        }

    }

}