namespace TDHeart {

    public class SkillSubEntity {

        public int typeID;
        public string typeName;

        public SkillAutoCastType autoCastType;
        public SkillCastAimType castAimType;
        public EntityFlag castTargetEntityFlag;
        public float castRange;
        public float cd;
        public float cdMax;
        public float maintain;
        public float maintainTimer;
        public float interval;
        public float intervalTimer;

        public bool hasSpawnBullet;
        public int spawnBulletTypeID;

    }

}