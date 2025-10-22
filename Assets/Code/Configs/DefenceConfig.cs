using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "DefenceConfig", menuName = "Configs/TrainingElementConfig/DefenceConfig", order = 0)]
    public class DefenceConfig : TrainingElementConfig<DefenceTarget>
    {
        public override TrainingElement Create(SceneContext context)
        {
            var obj = context.poolInit.poolDefence.Get();
            return obj;
        }
    }
}
