using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "DodgeConfig", menuName = "Configs/TrainingElementConfig/DodgeConfig", order = 0)]
    public class DodgeConfig : TrainingElementConfig<DodgeTarget>
    {
        public float SpeedDefault;
        public override TrainingElement Create(SceneContext context)
        {
            var obj = context.poolInit.poolDodge.Get();
            obj.Init(SpeedDefault, localPos, localEuler);
            return obj;
        }
    }
}
