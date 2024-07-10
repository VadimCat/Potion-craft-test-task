using System;
using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes.Scoring
{
    public class Score: IScore, IDisposable
    {
        private int _value;
        public int Value
        {
            get => _value;
            private set
            {
                _value = value;
                ScoreChanged?.Invoke(_value);
            }
        }

        public event Action<int> ScoreChanged;

        public void Dispose()
        {
            ScoreChanged = null;
        }
        
        public Score(IDishPublisher dishPublisher)
        {
            dishPublisher.EventDishReady += OnDishReady;
        }

        private void OnDishReady(IDish dish)
        {
            Value = dish.Score.Score;
        }
    }
}