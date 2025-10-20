using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitTarget : MonoBehaviour
{
    public ActionType type;
    [Header("Hit validation")]
    public float minSpeed = 1.2f;
    [Range(0f, 1f)] public float minDot = 0.6f;
    public Transform expectedBasis;

    System.Action<HitTarget> _onHit;

    public void Init(ActionType t, System.Action<HitTarget> onHit)
    {
        type = t; _onHit = onHit;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<VelocityProvider>(out var velocity))
        {
            Debug.Log("punch");
            velocity = other.GetComponent<VelocityProvider>();
            if (velocity == null) return;

            var v = velocity.Velocity;
            if (v.magnitude < minSpeed) return;

            var exp = ExpectedDir();
            var dot = Vector3.Dot(v.normalized, exp);
            if (dot < minDot) return;

            _onHit?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private Vector3 ExpectedDir()
    {
        var basis = expectedBasis ? expectedBasis : transform;
        switch (type)
        {
            case ActionType.JabL:
            case ActionType.JabR:
            case ActionType.CrossL:
            case ActionType.CrossR:
                return basis.forward; // удар вперёд
            default:
                return basis.forward;
        }
    }
}
