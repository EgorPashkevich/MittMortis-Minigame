using System;
using TMPro;
using UnityEngine;

namespace MittMortis
{  
    public class AttackTarget : TrainingElement
    {
        [SerializeField] private HandType handType;
        [SerializeField] private UITimer timer;
        [Header("Hit validation")]
        [SerializeField, Range(0f, 1f)] private float minDot = 0.6f;
        [SerializeField] private float minSpeed = 1.2f;
        [SerializeField] private Transform expectedBasis;
        [SerializeField] private float timeLife;

        [SerializeField] private TMP_Text textHand;

        public void Init(HandType type, string text, Vector3 localPos, Vector3 localEuler)
        {
            handType = type;
            textHand.text = text;
            transform.localPosition = localPos;
            transform.transform.localEulerAngles = localEuler;
            timer.SetTime(timeLife);
            timer.OnTimerEnd += () =>
            {
                Failure();
            };
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<VelocityProvider>(out var velocity))
            {
                if(velocity.HandType != handType)
                {
                    Failure();
                    return;
                }
                var v = velocity.Velocity;
                if (v.magnitude < minSpeed)
                {
                    Failure();
                    return;
                }

                var dot = Vector3.Dot(v.normalized, expectedBasis.forward);
                if (dot < minDot)
                {
                    Failure();
                    return;
                }

                Success();
            }
        }
    }
}
