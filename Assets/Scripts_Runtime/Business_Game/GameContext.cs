namespace TDHeart {

    public class GameContext {

        public PlayerEntity player;
        public CellRepository cellRepository;
        public TowerRepository towerRepository;
        public RoleRepository roleRepository;
        public PropRepository propRepository;

        public IDService idService;

        public UIContext uiContext;
        public TemplateContext templateContext;

        public GameContext() {

            player = new PlayerEntity();

            cellRepository = new CellRepository();
            towerRepository = new TowerRepository();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();

            idService = new IDService();

        }

        public void Inject(UIContext uiContext, TemplateContext templateContext) {
            this.uiContext = uiContext;
            this.templateContext = templateContext;
        }

    }

}