using System;

namespace PotionCraft.Models.Dishes.Scoring
{
    public interface IScore
    {
        int Value { get; }
        public event Action<int> ScoreChanged; 
    }
}