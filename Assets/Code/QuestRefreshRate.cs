using UnityEngine;

public class QuestRefreshRate : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
    }
}