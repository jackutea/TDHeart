namespace TDHeart {

    public class GameContext {

        public CellRepository cellRepository;
        public TowerRepository towerRepository;
        public RoleRepository roleRepository;

        public IDService idService;

        public TemplateContext templateContext;

        public GameContext() {
            cellRepository = new CellRepository();
            towerRepository = new TowerRepository();
            roleRepository = new RoleRepository();
            
            idService = new IDService();

        }

        public void Inject(TemplateContext templateContext) {
            this.templateContext = templateContext;
        }

    }

}