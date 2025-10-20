using UnityEngine;

public class XRCentering : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] float distanceFromCamera = 1.2f;
    [SerializeField] float heightOffset = -0.2f;

    void Start() => CenterContent();

    public void CenterContent()
    {
        var cam = Camera.main; if (!cam) return;
        var fwd = cam.transform.forward; fwd.y = 0f; fwd.Normalize();
        var pos = cam.transform.position + fwd * distanceFromCamera;
        pos.y = cam.transform.position.y + heightOffset;

        contentRoot.position = pos;
        contentRoot.rotation = Quaternion.LookRotation(fwd, Vector3.up);
    }
}
