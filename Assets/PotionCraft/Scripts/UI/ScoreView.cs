using System;
using PotionCraft.Models.Dishes.Scoring;
using TMPro;
using UnityEngine;

namespace PotionCraft.Scripts.UI
{
    public class ScoreView: MonoBehaviour, IScore
    {
        const string ScoreFormat = "Score: {0}";
        
        [SerializeField] private TMP_Text text;
        
        private IScore _scoreImplementation;
        public int Value => _scoreImplementation.Value;

        public event Action<int> ScoreChanged
        {
            add => _scoreImplementation.ScoreChanged += value;
            remove => _scoreImplementation.ScoreChanged -= value;
        }
        
        public void Construct(IScore score)
        {
            _scoreImplementation = score;
            _scoreImplementation.ScoreChanged += OnScoreChanged;
            
            OnScoreChanged(0);
        }

        private void OnScoreChanged(int obj)
        {
            text.text = string.Format(ScoreFormat, Value);
        }
        
        private void OnDestroy()
        {
            if (_scoreImplementation != null)
            {
                _scoreImplementation.ScoreChanged -= OnScoreChanged;
            }
        }
    }
}