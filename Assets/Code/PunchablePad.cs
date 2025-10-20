using UnityEngine;

public class PunchablePad : MonoBehaviour
{
    [Header("Pad Settings")]
    public string padName = "Start";
    public float minHitVelocity = 1.5f;


    private void OnTriggerEnter(Collider other)
    { 
        if (other.TryGetComponent<VelocityProvider>(out var velocity))
        {
            Debug.Log($"hit with velocity {velocity.Velocity.magnitude:F2}");
            if (velocity == null || velocity.Velocity.magnitude < minHitVelocity) return;

            if (padName == "Start")
                GameInitializer.Instance.StartRound();

            // TODO: Не забудь удалить строчку ниже
            this.gameObject.SetActive(false);
        }
    }
}
