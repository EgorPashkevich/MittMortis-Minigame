using System;
using UnityEngine;

namespace MittMortis
{
    [RequireComponent(typeof(Collider))]
    public class TrainingElement : MonoBehaviour
    {
        public event Action OnSuccess;
        public event Action OnFailure;

        public void Success()
        {
            gameObject.SetActive(false);
            OnSuccess?.Invoke();
        }
        public void Failure()
        {
            gameObject.SetActive(false);
            OnFailure?.Invoke();
        }
    }
}
