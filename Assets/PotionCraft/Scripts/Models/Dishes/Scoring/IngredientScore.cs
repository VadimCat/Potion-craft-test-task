using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Scoring
{
    [CreateAssetMenu(fileName = "IngredientScore", menuName = "PotionCraft/Scoring/IngredientScore")]
    public class IngredientScore : ScriptableObject
    {
        [field: SerializeField] public IngredientId IngredientId { get; private set; }
        [field: SerializeField] public int Score { get; private set; }
    }
}