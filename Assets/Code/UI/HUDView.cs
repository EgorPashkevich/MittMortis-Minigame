using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MittMortis.UI
{
    [Serializable]
    public class HUDView
    {
        [SerializeField] GameController controller;
        [Header("Labels")]
        [SerializeField] private TextMeshProUGUI txtScore;
        [SerializeField] private TextMeshProUGUI txtHigh;
        [SerializeField] private TextMeshProUGUI txtStreak;
        [SerializeField] private TextMeshProUGUI txtLife;
        private GameSession session;

        //[Header("Lives")]
        //public Image[] lifeIcons;

        public void Init()
        {
            session = controller.gameSession;
        }
        public void OnEnable()
        {
            session.OnAnyChanged += Refresh;
            Refresh();
        }

        public void OnDisable()
        {
            session.OnAnyChanged -= Refresh;
        }

        void Refresh()
        {
            txtScore.text = $"Score: {session.Score}";
            txtHigh.text = $"High: {session.HighScore}";
            txtStreak.text = $"Streak: {session.Streak}";
            txtLife.text = $"Life: {session.Lives}";
        }
    }
}
