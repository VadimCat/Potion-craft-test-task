using System;
using PotionCraft.Models.Dishes;
using PotionCraft.Models.Ingredients;
using UnityEngine;

namespace PotionCraft.SceneView
{
    public class CauldronSceneView: MonoBehaviour, ICauldron
    {
        public IngredientsMix Ingredients => _cauldronImplementation.Ingredients;
        private ICauldron _cauldronImplementation;
        
        public event Action<IDish> EventDishReady
        {
            add => _cauldronImplementation.EventDishReady += value;
            remove => _cauldronImplementation.EventDishReady -= value;
        }

        public void Construct(ICauldron cauldronImplementation)
        {
            _cauldronImplementation = cauldronImplementation;
        }

        public void AddIngredient(IIngredient ingredient)
        {
            _cauldronImplementation.AddIngredient(ingredient);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IngredientSceneView ingredientSceneView))
            {
                AddIngredient(ingredientSceneView.Implementation);
                ingredientSceneView.DeSpawn();
            }
            
        }
    }
}