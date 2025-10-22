using System;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private Image fillImage;
    [SerializeField] private bool autoStart = false;

    public event Action OnTimerEnd;

    private float totalTime;
    private float remainingTime;
    private bool isRunning;

    public void SetTime(float seconds)
    {
        totalTime = seconds;
        remainingTime = seconds;
        UpdateFill();
        isRunning = autoStart;
    }

    public void StartTimer() => isRunning = true;
    public void PauseTimer() => isRunning = false;
    public void ResetTimer()
    {
        remainingTime = totalTime;
        UpdateFill();
        isRunning = false;
    }

    void Update()
    {
        if (!isRunning || totalTime <= 0f) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            isRunning = false;
            OnTimerEnd?.Invoke();
        }

        UpdateFill();
    }

    private void UpdateFill()
    {
        if (fillImage != null && totalTime > 0f)
            fillImage.fillAmount = remainingTime / totalTime;
    }
}
