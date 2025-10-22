using UnityEngine;
public class VelocityProvider : MonoBehaviour
{
    [field: SerializeField] public HandType HandType {  get; private set; }
    [Range(0f, 1f)] public float smoothing = 0.15f;
    [field: SerializeField] public Vector3 Velocity { get; private set; }
    private Vector3 _last; 
    private bool _init;
    void Update()
    {
        if (!_init) { _last = transform.position; _init = true; return; }
        var raw = (transform.position - _last) / Mathf.Max(Time.deltaTime, 1e-6f);
        Velocity = Vector3.Lerp(Velocity, raw, 1f - Mathf.Exp(-smoothing * 60f * Time.deltaTime));
        _last = transform.position;
    }
}
