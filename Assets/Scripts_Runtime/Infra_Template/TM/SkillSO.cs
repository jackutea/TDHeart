using UnityEngine;

namespace TDHeart {

    [CreateAssetMenu(fileName = "SO_Skill_", menuName = "TDHeart/SO_Skill", order = 0)]
    public class SkillSO : ScriptableObject {

        public int typeID;
        public string typeName;

        public SkillAutoCastType autoCastType;
        public SkillCastAimType castAimType;
        public EntityFlag castTargetEntityFlag;
        public float castRange;
        public float cd;
        public float maintain;
        public float interval;

        public bool hasSpawnBullet;
        public int spawnBulletTypeID;

    }

}