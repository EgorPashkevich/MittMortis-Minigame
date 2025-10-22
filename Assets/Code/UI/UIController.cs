using TMPro;
using UnityEngine;

namespace MittMortis.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private HUDView hUDView;
        public TMP_Text fpsText;
        float deltaTime;

        private void Awake()
        {
            hUDView.Init();
        }
        private void OnEnable()
        {
            hUDView.OnEnable();
        }

        private void OnDisable()
        {
            hUDView.OnDisable();
        }
        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            fpsText.text = $"FPS: {fps:0}";
        }
    }
}
