using System;
using UnityEngine;

namespace MittMortis
{
    [Serializable]
    public class XRCentering
    {
        [SerializeField] Transform contentRoot;
        [SerializeField] Transform counterDodgeTargets;
        [SerializeField] float distanceFromCamera = 1.2f;
        [SerializeField] float heightOffset = -0.2f;

        public void Init()
        {
            var camera = Camera.main; 
            if (!camera) return;
            var forward = camera.transform.forward; 
            forward.y = 0f; forward.Normalize();
            var position = camera.transform.position + forward * distanceFromCamera;
            position.y = camera.transform.position.y + heightOffset;

            contentRoot.position = position;
            contentRoot.rotation = Quaternion.LookRotation(forward, Vector3.up);

            counterDodgeTargets.position = camera.transform.position - forward * 0.5f;
            counterDodgeTargets.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
