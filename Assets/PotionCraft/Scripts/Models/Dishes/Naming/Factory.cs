using PotionCraft.Models.Dishes.Naming.Specification;
using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.Models.Dishes.Naming
{
    [CreateAssetMenu(fileName = "RangeAmountDish", menuName = "PotionCraft/DishName/Factory")]
    public class NameFactory: ScriptableObject
    {
        [SerializeField] private DishNameSpecification[] specifications;
        [SerializeField] private DishNameSpecification defaultSpecification;

        public DishName Create(IngredientsMix ingredients)
        {
            foreach (var specification in specifications)
            {
                if (specification.Match(ingredients))
                {
                    return new DishName(specification.Name);
                }
            }

            return new DishName(defaultSpecification.Name);
        }
    }
}