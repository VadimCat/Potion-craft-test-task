using PotionCraft.Models.Ingredients;
using PotionCraft.SceneView.Input;
using UnityEngine;

namespace PotionCraft.SceneView
{
    public class IngredientSpawn : MonoBehaviour, IPointerDownHandler
    {
        [field: SerializeField] public IngredientId IngredientId { get; private set; }
        [field: SerializeField] public float MinSpawnHeight { get; private set; }

        private IngredientSceneView.Factory _ingredientFactory;
        private PointerDrag _pointerDrag;
        private Bounds2DPhysics _bounds;

        public void Construct(IngredientSceneView.Factory ingredientFactory, PointerDrag pointerDrag, Bounds2DPhysics bounds)
        {
            _bounds = bounds;
            _pointerDrag = pointerDrag;
            _ingredientFactory = ingredientFactory;
        }

        public void HandleDown(Vector3 position)
        {
            //limiting the spawn height to avoid stuck ingredients
            position.y = Mathf.Max(position.y, MinSpawnHeight);
            _pointerDrag.AddDraggable(_ingredientFactory.Create(new Ingredient(IngredientId), _bounds, position),
                position);
        }
    }
}