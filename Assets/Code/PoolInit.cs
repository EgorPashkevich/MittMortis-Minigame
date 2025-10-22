using System;
using UnityEngine;

namespace MittMortis
{
    [Serializable]
    public class PoolInit
    {
        public event Action<TrainingElement> OnObjectRelease;

        [SerializeField] AttackTarget attackTarget;
        [SerializeField] DefenceTarget defenceTarget;
        [SerializeField] DodgeTarget dodgeTarget;

        public CustomObjectPool<AttackTarget> poolAttack { get; private set; }
        public CustomObjectPool<DefenceTarget> poolDefence { get; private set; }
        public CustomObjectPool<DodgeTarget> poolDodge { get; private set; }

        public void Init(Transform transformPool)
        {
            poolAttack = new CustomObjectPool<AttackTarget>(attackTarget, 5, transformPool);
            poolAttack.OnEventRelease += (obj) => { OnObjectRelease?.Invoke(obj); };

            poolDefence = new CustomObjectPool<DefenceTarget>(defenceTarget, 5, transformPool);
            poolDefence.OnEventRelease += (obj) => { OnObjectRelease?.Invoke(obj); };

            poolDodge = new CustomObjectPool<DodgeTarget>(dodgeTarget, 5, transformPool);
            poolDodge.OnEventRelease += (obj) => { OnObjectRelease?.Invoke(obj); };
        }
    }
}