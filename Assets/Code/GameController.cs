using MittMortis.Config;
using UnityEditor;
using UnityEngine;

namespace MittMortis
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private XRCentering XRCentering;
        [SerializeField] private SettingsLevel settingsLevel;
        [SerializeField] private TargetSpawner spawner;

        [SerializeField] private Transform Menu;

        public GameSession gameSession;

        private bool _running;
        private float _nextAt;

        private float spawnInterval;

        private void Awake()
        {
            XRCentering.Init();
            spawner.Init(gameSession);   
            gameSession.Init();

            gameSession.OnStopGame += StopRun;
            spawner.OnEndPackElements += EnterMultipler;
        }
        public void StartRun()
        {
            _running = true;
            _nextAt = Time.time + settingsLevel.startDelay;
            Menu.gameObject.SetActive(false);
            gameSession.ResetRun(settingsLevel.CountLives);
            spawnInterval = settingsLevel.StartSpawnInterval;
        }

        public void StopRun()
        {
            _running = false;
            Menu.gameObject.SetActive(true);
            gameSession.ClearList();
        }
        
        public void EnterMultipler()
        {
            spawnInterval *= settingsLevel.MultiplerSpawnInterval;
            spawnInterval = Mathf.Clamp(spawnInterval, 0.8f, settingsLevel.StartSpawnInterval);
        }

        private void Update()
        {
            if (!_running) return;
            if (Time.time < _nextAt) return;

            spawner.Spawn();

            _nextAt = Time.time + spawnInterval;
        }
    }
}
