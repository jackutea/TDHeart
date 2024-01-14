namespace TDHeart {

    public class GameContext {

        public CellRepository cellRepository;

        public IDService idService;

        public GameContext() {
            cellRepository = new CellRepository();
            idService = new IDService();
        }

    }

}