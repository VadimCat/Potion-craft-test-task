using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Naming.Specification
{
    [CreateAssetMenu(fileName = "RangeAmountDish", menuName = "PotionCraft/DishName/RangeAmountDish")]
    public class RangeAmountDish : DishNameSpecification
    {
        [field: SerializeField] private int MinAmount { get; set; }
        [field: SerializeField] private int MaxAmount { get; set; }
        [field: SerializeField] private IngredientId IngredientId { get; set; }

        /// <summary>
        /// Check if the amount of the ingredient is within the range specified
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public override bool Match(IngredientsMix ingredients)
        {
            var count = ingredients.IngredientAmount(IngredientId);
            return count >= MinAmount && count <= MaxAmount;
        }
    }
}