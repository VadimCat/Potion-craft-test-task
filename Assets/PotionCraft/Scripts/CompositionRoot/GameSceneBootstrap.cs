using Ji2.Pools;
using Modules.Input.Tap;
using PotionCraft.Models.Dishes;
using PotionCraft.Models.Dishes.DishListeners;
using PotionCraft.Models.Dishes.Naming;
using PotionCraft.Models.Dishes.Scoring;
using PotionCraft.Models.Ingredients;
using PotionCraft.SceneView;
using PotionCraft.SceneView.Input;
using PotionCraft.Scripts.UI;
using UnityEngine;

namespace PotionCraft.CompositionRoot
{
    public class GameSceneBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform ingredientsParent;
        [SerializeField] private IngredientSpawn[] ingredientSpawns;
        [SerializeField] private CauldronSceneView cauldronSceneView;
        [SerializeField] private GameScreen gameScreen;
        [SerializeField] private Bounds2DPhysics bounds;
        [SerializeField] private Camera sceneCamera;
        private GameInput _gameInput;

        public void Construct(ScoreFactory scoreFactory, NameFactory nameFactory, TapInputAction tapInputAction,
            PointerDrag pointerDrag, Hover hover, IngredientsViewConfig ingredientsViewConfig)
        {
            var cauldron = new Cauldron(new Dish.Factory(nameFactory, scoreFactory));
            cauldronSceneView.Construct(cauldron);

            gameScreen.Construct(new LastDish(cauldron), new BestDish(cauldron), new Score(cauldron),
                ingredientsViewConfig);

            foreach (IngredientSpawn spawn in ingredientSpawns)
            {
                Pool<IngredientSceneView> ingredientPool =
                    new(ingredientsViewConfig.Prefab(spawn.IngredientId), ingredientsParent, 5);

                IngredientSceneView.Factory ingredientFactory = new(ingredientPool);

                spawn.Construct(ingredientFactory, pointerDrag, bounds);
            }

            _gameInput = new GameInput(tapInputAction, pointerDrag, hover, sceneCamera);
        }

        private void OnDestroy()
        {
            _gameInput?.Dispose();
        }
    }
}