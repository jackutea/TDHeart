using UnityEngine;

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
        public CameraContext cameraContext;

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

        public void Inject(UIContext uiContext, TemplateContext templateContext, CameraContext cameraContext) {
            this.uiContext = uiContext;
            this.templateContext = templateContext;
            this.cameraContext = cameraContext;
        }

        public bool TryGetNearestEntity(EntityFlag entityFlag, AllyFlag allyFlag, Vector3 pos, float range, out EntityFlag outEntityFlag, out int outID) {

            outEntityFlag = EntityFlag.None;
            outID = 0;
            bool has = false;

            if (!has && entityFlag.HasFlag(EntityFlag.Tower)) {
                has = towerRepository.TryGetNearest(pos, allyFlag, range, out var tower);
                if (has) {
                    outEntityFlag = tower.entityType;
                    outID = tower.id;
                }
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Role)) {
                has = roleRepository.TryGetNearest(pos, allyFlag, range, out var role);
                if (has) {
                    outEntityFlag = role.entityType;
                    outID = role.id;
                }
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Prop)) {
                has = propRepository.TryGetNearest(pos, allyFlag, range, out var prop);
                if (has) {
                    outEntityFlag = prop.entityType;
                    outID = prop.id;
                }
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Bullet)) {
                has = bulletRepository.TryGetNearest(pos, allyFlag, range, out var bullet);
                if (has) {
                    outEntityFlag = bullet.entityType;
                    outID = bullet.id;
                }
            }

            return has;
        }

        public bool TryGetEntityPos(EntityFlag entityFlag, int id, out Vector3 pos) {

            pos = Vector3.zero;
            bool has = false;

            if (!has && entityFlag.HasFlag(EntityFlag.Tower)) {
                has = towerRepository.TryGet(id, out var tower);
                pos = tower.lpos;
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Role)) {
                has = roleRepository.TryGet(id, out var role);
                pos = role.lpos;
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Prop)) {
                has = propRepository.TryGet(id, out var prop);
                pos = prop.lpos;
            }

            if (!has && entityFlag.HasFlag(EntityFlag.Bullet)) {
                has = bulletRepository.TryGet(id, out var bullet);
                pos = bullet.lpos;
            }

            return has;
        }

    }

}