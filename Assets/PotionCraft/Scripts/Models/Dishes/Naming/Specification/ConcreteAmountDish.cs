using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Naming.Specification
{
    [CreateAssetMenu(fileName = "ConcreteIngredientAmountDish", menuName = "PotionCraft/DishName/ConcreteIngredientAmountDish")]
    public class ConcreteAmountDish : DishNameSpecification
    {
        [field: SerializeField] private int Amount { get; set; }
        [field: SerializeField] private IngredientId IngredientId { get; set; }

        /// <summary>
        /// Check if the amount of the ingredient is equal to the amount specified
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public override bool Match(IngredientsMix ingredients)
        {
            return ingredients.IngredientAmount(IngredientId) == Amount;
        }
    }
}