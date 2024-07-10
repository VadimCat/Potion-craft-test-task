using System;
using PotionCraft.Models.Dishes;
using PotionCraft.Models.Dishes.DishListeners;
using PotionCraft.SceneView;
using TMPro;
using UnityEngine;

namespace PotionCraft.Scripts.UI
{
    public class CachedDishListenerView : MonoBehaviour, ICachedDishListener
    {
        [SerializeField] private TMP_Text text;

        private DishStringBuilder _dishStringBuilder;
        private ICachedDishListener _dishListener;
        private string _prefix = "";
        public IDish CurrentDish => _dishListener.CurrentDish;

        public event Action<IDish> DishCreated
        {
            add => _dishListener.DishCreated += value;
            remove => _dishListener.DishCreated -= value;
        }

        public void Construct(ICachedDishListener dishListener, IngredientsViewConfig ingredientsViewConfig, string prefix = "")
        {
            _prefix = prefix;
            _dishListener = dishListener;
            _dishStringBuilder = new DishStringBuilder(prefix, ingredientsViewConfig);
            DishCreated += OnDishCreated;
            
            OnDishCreated(Dish.Empty());
        }

        private void OnDishCreated(IDish dish)
        {
            text.text = _dishStringBuilder.DishText(dish);
        }

        private void OnDestroy()
        {
            if (_dishListener != null)
            {
                _dishListener.DishCreated -= OnDishCreated;
            }
        }
    }
}