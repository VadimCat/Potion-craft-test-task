using UnityEngine;

namespace PotionCraft.Models.Ingredients
{
    [CreateAssetMenu(fileName = "IngredientId", menuName = "PotionCraft/IngredientId")]
    public class IngredientId: ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
    }
}