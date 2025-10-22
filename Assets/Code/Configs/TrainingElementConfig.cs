using UnityEngine;

namespace MittMortis.Config
{
    public class SceneContext
    {
        public PoolInit poolInit;
    } 
    public abstract class TrainingElementConfig : ScriptableObject      
    {
        public Vector3 localPos;
        public Vector3 localEuler;
        public abstract TrainingElement Create(SceneContext context);
    }
    public abstract class TrainingElementConfig<T> : TrainingElementConfig
        where T : TrainingElement
    {
        public T prefab;
    }
}
