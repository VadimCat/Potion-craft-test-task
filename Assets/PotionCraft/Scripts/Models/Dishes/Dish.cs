using System.Collections.Generic;
using PotionCraft.Models.Dishes.Naming;
using PotionCraft.Models.Dishes.Scoring;
using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes
{
    public class Dish: IDish
    {
        private readonly IEnumerable<IIngredient> _ingredients;

        public IDishName Name { get; }

        public IDishScore Score { get; }

        public IngredientsMix Ingredients { get; }

        public static Dish Empty() => new Dish(new IngredientsMix(), DishName.Default, DishScore.Default);
        
        private Dish(IngredientsMix ingredients, DishName name, IDishScore score)
        {
            Ingredients = ingredients;
            Name = name;
            Score = score;
        }

        public class Factory
        {
            private readonly NameFactory _nameFactory;
            private readonly ScoreFactory _scoreFactory;

            public Factory(NameFactory nameFactory, ScoreFactory scoreFactory)
            {
                _nameFactory = nameFactory;
                _scoreFactory = scoreFactory;
            }
            
            public IDish Create(IngredientsMix ingredients)
            {
                return new Dish(ingredients, _nameFactory.Create(ingredients), _scoreFactory.Create(ingredients));
            }
        }
    }
}