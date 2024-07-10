using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Scoring
{
    [CreateAssetMenu(fileName = "ScoreFactory", menuName = "PotionCraft/Scoring/ScoreFactory")]
    public class ScoreFactory : ScriptableObject
    {
        [UsedImplicitly, System.Serializable]
        private class ComboMultiplier
        {
            /// <summary>
            /// Amount of ingredients in the combo
            /// </summary>
            [field: SerializeField] public int Amount { get; set; }
            [field: SerializeField] public float Multiplier { get; set; }
        }

        [field: SerializeField] private ComboMultiplier[] Multipliers { get; set; }
        [field: SerializeField] private IngredientScore[] Scores { get; set; }

        private Dictionary<IngredientId, int> _scoreMap;
        private Dictionary<int, float> _multiplierMap;

        /// <summary>
        /// Bootstrap the score and multiplier maps,
        /// call first before using the object
        /// </summary>
        public void Bootstrap()
        {
            _scoreMap = new();
            _multiplierMap = new();
            
            foreach (var score in Scores)
            {
                _scoreMap.Add(score.IngredientId, score.Score);
            }

            foreach (var multiplier in Multipliers)
            {
                _multiplierMap.Add(multiplier.Amount, multiplier.Multiplier);
            }
        }

        /// <summary>
        /// Score of the dish
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public IDishScore Create(IngredientsMix ingredients)
        {
            if(_scoreMap == null || _multiplierMap == null)
            {
                throw new NotBootedException();
            }

            // Calculate the score: sum of the score of each ingredient multiplied by the number of occurrences and the multiplier
            return new DishScore((int)ingredients.IngredientsAmount.Sum(occurrence =>
                _scoreMap[occurrence.Key] * occurrence.Value * _multiplierMap[occurrence.Value]));
        }
    }
}