namespace TDHeart {

    public class GameEntity {

        public GameStatus status;

        public bool failed_isEntering;

        public void Normal_Enter() {
            status = GameStatus.Normal;
        }

        public void Failed_Enter() {
            status = GameStatus.Failed;
            failed_isEntering = true;
        }
        
    }

}