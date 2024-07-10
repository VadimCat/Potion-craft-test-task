using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Naming.Specification
{
    [CreateAssetMenu(fileName = "DefaultDish", menuName = "PotionCraft/DishName/DefaultDish")]
    public class DefaultDish : DishNameSpecification
    {
        /// <summary>
        /// always return true
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public override bool Match(IngredientsMix ingredients)
        {
            return true;
        }
    }
}