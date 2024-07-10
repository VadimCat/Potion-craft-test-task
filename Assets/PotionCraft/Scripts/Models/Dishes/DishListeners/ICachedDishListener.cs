namespace PotionCraft.Models.Dishes.DishListeners
{
    public interface ICachedDishListener: IDishListener
    {
        public IDish CurrentDish { get; }
    }
}