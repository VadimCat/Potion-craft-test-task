using System;
using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes.DishListeners
{
    public abstract class DishListener : ICachedDishListener, IDisposable
    {
        private readonly IDishPublisher _dishPublisher;
    
        private IDish _currentDish;
        public IDish CurrentDish
        {
            get => _currentDish;
            protected set
            {
                _currentDish = value;
                DishCreated?.Invoke(_currentDish);
            }
        }
        public event Action<IDish> DishCreated;

        protected DishListener(IDishPublisher dishPublisher)
        {
            _dishPublisher = dishPublisher;
            dishPublisher.EventDishReady += OnDishReady;
        }

        public void Dispose()
        {
            _dishPublisher.EventDishReady -= OnDishReady;
        }
    
        protected abstract void OnDishReady(IDish dish);
    }
}