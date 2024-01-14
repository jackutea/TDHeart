namespace TDHeart {

    public class MainContext {

        public GameContext gameContext;

        public TemplateContext templateContext;

        public MainContext() {
            gameContext = new GameContext();
            templateContext = new TemplateContext();

            gameContext.Inject(templateContext);
        }

    }

}