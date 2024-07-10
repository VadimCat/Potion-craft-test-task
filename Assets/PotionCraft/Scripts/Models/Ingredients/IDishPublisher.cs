using System;
using PotionCraft.Models.Dishes;

namespace PotionCraft.Models.Ingredients
{
    public interface IDishPublisher
    {
        event Action<IDish> EventDishReady;
    }
}