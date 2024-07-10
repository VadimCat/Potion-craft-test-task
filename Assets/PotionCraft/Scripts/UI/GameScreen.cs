using PotionCraft.Models.Dishes.DishListeners;
using PotionCraft.Models.Dishes.Scoring;
using PotionCraft.SceneView;
using UnityEngine;
using UnityEngine.UI;

namespace PotionCraft.Scripts.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Button restart;
        [SerializeField] private CachedDishListenerView lastDish;
        [SerializeField] private CachedDishListenerView bestDish;
        [SerializeField] private ScoreView score;

        const string LastDish = "Последнее блюдо: ";
        const string BestDish = "Лучшее блюдо: ";

        public void Construct(ICachedDishListener lastDish, ICachedDishListener bestDish, IScore score,
            IngredientsViewConfig ingredientsViewConfig)
        {
            this.lastDish.Construct(lastDish, ingredientsViewConfig, LastDish);
            this.bestDish.Construct(bestDish, ingredientsViewConfig, BestDish);
            this.score.Construct(score);
        }
    }
}