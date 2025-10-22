using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "AttackConfig", menuName = "Configs/TrainingElementConfig/AttackConfig", order = 0)]
    public class AttackConfig : TrainingElementConfig<AttackTarget>
    {
        public HandType type;
        public string HandText;

        public override TrainingElement Create(SceneContext context)
        {
            var obj = context.poolInit.poolAttack.Get();
            obj.Init(type, HandText, localPos, localEuler);
            return obj;
        }
    }
}
