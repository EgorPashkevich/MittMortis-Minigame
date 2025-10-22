using UnityEngine;

namespace MittMortis
{
    public class PunchableStart : MonoBehaviour
    {
        [SerializeField] private GameController controller;
        [Header("Pad Settings")]
        public float minHitVelocity = 1.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<VelocityProvider>(out var velocity))
            {
                if (velocity == null || velocity.Velocity.magnitude < minHitVelocity) return;

                controller.StartRun();
            }
        }
    }
}
