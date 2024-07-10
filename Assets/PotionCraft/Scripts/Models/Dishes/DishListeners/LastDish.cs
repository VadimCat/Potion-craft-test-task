using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes.DishListeners
{
    public class LastDish: DishListener
    {
        public LastDish(IDishPublisher dishPublisher) : base(dishPublisher)
        {
        }

        protected override void OnDishReady(IDish dish)
        {
            CurrentDish = dish;
        }
    }
}