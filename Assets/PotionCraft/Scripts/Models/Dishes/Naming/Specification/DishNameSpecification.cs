using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Naming.Specification
{
    public abstract class DishNameSpecification: ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }

        /// <summary>
        /// Check if the ingredients match the specification pattern
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        public abstract bool Match(IngredientsMix ingredients);
    }
}