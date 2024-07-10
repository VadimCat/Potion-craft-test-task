using System.Linq;
using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.SceneView
{
    [CreateAssetMenu(fileName = "IngredientsViewConfig", menuName = "PotionCraft/IngredientsView/IngredientsViewConfig")]
    public class IngredientsViewConfig: ScriptableObject
    {
        [SerializeField] private IngredientViewConfig[] ingredients;
        
        public string Name(IngredientId ingredientId)
        {
            return ingredients.First(i => i.IngredientId == ingredientId).Name;
        }
        
        public Sprite Icon(IngredientId ingredientId)
        {
            return ingredients.First(i => i.IngredientId == ingredientId).Sprite;
        }

        public IngredientSceneView Prefab(IngredientId ingredientId)
        {
            return ingredients.First(i => i.IngredientId == ingredientId).Prefab;
        }
    }
}