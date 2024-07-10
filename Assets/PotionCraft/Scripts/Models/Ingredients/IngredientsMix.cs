using System.Collections.Generic;
using System.Linq;

namespace PotionCraft.Models.Ingredients
{
    public class IngredientsMix
    {
        private readonly Dictionary<IngredientId, int> _ingredientsAmount = new();
        public IReadOnlyDictionary<IngredientId, int> IngredientsAmount => _ingredientsAmount;

        public void Add(IIngredient ingredientId)
        {
            if (_ingredientsAmount.ContainsKey(ingredientId.Id))
            {
                _ingredientsAmount[ingredientId.Id]++;
            }
            else
            {
                _ingredientsAmount[ingredientId.Id] = 1;
            }
        }

        public IEnumerable<IngredientId> AllIngredients()
        {
            foreach (var ingredient in IngredientsAmount)
            {
                for (int i = 0; i < ingredient.Value; i++)
                {
                    yield return ingredient.Key;
                }
            }
        }

        public int IngredientAmount(IngredientId ingredientId)
        {
            return IngredientsAmount.ContainsKey(ingredientId) ? IngredientsAmount[ingredientId] : 0;
        }
        
        public int Count()
        {
            return IngredientsAmount.Sum(i => i.Value);
        }
    }
}