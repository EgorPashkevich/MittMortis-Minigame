using UnityEngine;

public class Conductor : MonoBehaviour
{
    public TargetSpawner spawner;
    [Range(0.4f, 2f)] public float spawnInterval = 1.1f;
    public float startDelay = 0.8f;

    bool _running;
    float _nextAt;

    public void StartRun()
    {
        _running = true;
        _nextAt = Time.time + startDelay;
    }

    public void StopRun() => _running = false;

    private void Update()
    {
        if (!_running) return;
        if (Time.time < _nextAt) return;

        // проста€ чередовалка L/R
        var t = (Random.value < 0.5f) ? ActionType.JabL : ActionType.JabR;
        spawner.Spawn(t, OnHit);

        _nextAt = Time.time + spawnInterval;
    }

    private void OnHit(HitTarget t)
    {
        // TODO: тут будет начисление очков/стрик/фидбек
        // Ќа первое врем€ просто логнуть:
        Debug.Log($"Hit {t.type}");
    }
}
