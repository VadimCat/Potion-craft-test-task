using System;

namespace PotionCraft.Models.Dishes.DishListeners
{
    public interface IDishListener
    {
        public event Action<IDish> DishCreated; 
    }
}