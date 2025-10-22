using System;
using System.Collections.Generic;
using UnityEngine;

namespace MittMortis
{
    [Serializable]
    public class GameSession
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }
        public int Streak { get; private set; }
        public int Lives { get; private set; }

        private List<TrainingElement> activeTrainingElements = new();

        private int basePoints = 1;

        const string KeyHigh = "MM_HighScore";

        public event Action<int> OnScoreChanged;
        public event Action<int> OnHighScoreChanged;
        public event Action<int> OnStreakChanged;
        public event Action<int> OnLivesChanged;
        public event Action OnAnyChanged;

        public event Action OnStopGame;

        public void Init()
        {
            HighScore = PlayerPrefs.GetInt(KeyHigh, 0);
        }

        public void ResetRun(int lives = 3)
        {
            Score = 0;
            Streak = 0;
            Lives = lives;
            FireAll();
        }

        public void AddObject(TrainingElement trainingElement)
        {
            trainingElement.OnSuccess += AddScore;
            trainingElement.OnFailure += Miss;
            activeTrainingElements.Add(trainingElement);
        }

        public void ReleaseObject(TrainingElement trainingElement)
        {
            trainingElement.OnSuccess -= AddScore;
            trainingElement.OnFailure -= Miss;
            activeTrainingElements.Remove(trainingElement);
        }

        public void ClearList()
        {
            foreach (var trainingElement in activeTrainingElements)
            {
                trainingElement.gameObject.SetActive(false);
            }
            activeTrainingElements.Clear();
        }

        private void AddScore()
        {
            Streak++;
            int bonus = Mathf.RoundToInt(basePoints * Mathf.Clamp01((Streak - 1) * 0.1f));
            Score += basePoints + bonus;

            OnScoreChanged?.Invoke(Score);
            OnStreakChanged?.Invoke(Streak);

            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetInt(KeyHigh, HighScore);
                OnHighScoreChanged?.Invoke(HighScore);
            }

            OnAnyChanged?.Invoke();
        }

        private void Miss()
        {
            Streak = 0; 
            Lives = Mathf.Max(0, Lives - 1);

            if(Lives <= 0)
            {
                OnStopGame?.Invoke();
            }

            OnStreakChanged?.Invoke(Streak);
            OnLivesChanged?.Invoke(Lives);
            OnAnyChanged?.Invoke();
        }

        private void FireAll()
        {
            OnScoreChanged?.Invoke(Score);
            OnHighScoreChanged?.Invoke(HighScore);
            OnStreakChanged?.Invoke(Streak);
            OnLivesChanged?.Invoke(Lives);
            OnAnyChanged?.Invoke();
        }
    }
}
