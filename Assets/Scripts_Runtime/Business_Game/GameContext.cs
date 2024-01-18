namespace TDHeart {

    public class GameContext {

        public GameEntity game;
        public PlayerEntity player;
        public CellRepository cellRepository;
        public TowerRepository towerRepository;
        public RoleRepository roleRepository;
        public PropRepository propRepository;
        public BulletRepository bulletRepository;

        public IDService idService;

        public UIContext uiContext;
        public TemplateContext templateContext;

        public GameContext() {

            game = new GameEntity();
            player = new PlayerEntity();

            cellRepository = new CellRepository();
            towerRepository = new TowerRepository();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();
            bulletRepository = new BulletRepository();

            idService = new IDService();

        }

        public void Inject(UIContext uiContext, TemplateContext templateContext) {
            this.uiContext = uiContext;
            this.templateContext = templateContext;
        }

    }

}