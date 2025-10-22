using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace MittMortis
{
    public class DodgeTarget : TrainingElement
    {
        private float defaultSpeed;
        private float deathTime = 3f;

        public void Init(float speed, Vector3 localPos, Vector3 localEuler)
        {
            transform.localPosition = localPos;
            transform.transform.localEulerAngles = localEuler;
            defaultSpeed = speed;

            gameObject.SetActive(true);
            deathTime = 3f;
        }

        private void Update()
        {
            transform.position += -Vector3.forward * defaultSpeed * Time.deltaTime;
            deathTime -= Time.deltaTime;
            if (deathTime < 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<HeadPlayer>(out var head))
            {
                Failure();
                gameObject.SetActive(false);
            }

            if(other.gameObject.TryGetComponent<TriggerDodgeTarget>(out var counter))
            {
                Success();
                gameObject.SetActive(false);
            }
        }
    }
}
