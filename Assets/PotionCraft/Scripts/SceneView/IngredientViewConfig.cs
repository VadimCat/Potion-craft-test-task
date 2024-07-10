using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.SceneView
{
    [CreateAssetMenu(fileName = "IngredientViewConfig", menuName = "PotionCraft/IngredientsView/IngredientViewConfig")]
    public class IngredientViewConfig : ScriptableObject
    {
        [field: SerializeField] public IngredientId IngredientId { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public IngredientSceneView Prefab { get; private set; }
    }
}