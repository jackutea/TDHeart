namespace TDHeart {

    public class GameContext {

        public CellRepository cellRepository;
        public TowerRepository towerRepository;
        public RoleRepository roleRepository;
        public PropRepository propRepository;

        public IDService idService;

        public TemplateContext templateContext;

        public GameContext() {
            cellRepository = new CellRepository();
            towerRepository = new TowerRepository();
            roleRepository = new RoleRepository();
            propRepository = new PropRepository();
            
            idService = new IDService();

        }

        public void Inject(TemplateContext templateContext) {
            this.templateContext = templateContext;
        }

    }

}