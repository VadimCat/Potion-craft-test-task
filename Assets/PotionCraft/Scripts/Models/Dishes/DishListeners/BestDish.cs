using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes.DishListeners
{
    public class BestDish: DishListener
    {
        public BestDish(IDishPublisher dishPublisher) : base(dishPublisher)
        {
        }

        protected override void OnDishReady(IDish dish)
        {
            if (CurrentDish == null || dish.Score.Score > CurrentDish.Score.Score)
            {
                CurrentDish = dish;
            }
        }
    }
}