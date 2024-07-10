using System.Linq;
using System.Text;
using PotionCraft.Models.Dishes;
using PotionCraft.SceneView;

namespace PotionCraft.Scripts.UI
{
    public class DishStringBuilder
    {
        private readonly string _prefix;
        private readonly IngredientsViewConfig _ingredientViewConfig;
        private readonly StringBuilder _stringBuilder = new();

        public DishStringBuilder(string prefix, IngredientsViewConfig ingredientViewConfig)
        {
            _prefix = prefix;
            _ingredientViewConfig = ingredientViewConfig;
        }

        public string DishText(IDish dish)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(_prefix);
            _stringBuilder.Append($"{dish.Name.Name} ");
            _stringBuilder.Append('(');
            
            int amount = dish.Ingredients.IngredientsAmount.Values.Count();
            for (int i = 0; i < amount; i++)
            {
                var id = dish.Ingredients.IngredientsAmount.Keys.ElementAt(i);
                _stringBuilder.Append($"{dish.Ingredients.IngredientsAmount[id]} {_ingredientViewConfig.Name(id)}");

                if (i < amount - 1)
                {
                    _stringBuilder.Append(", ");
                }
            }
            _stringBuilder.Append(')');
            _stringBuilder.Append($"[{dish.Score.Score}]");
            return _stringBuilder.ToString();
        }
    }
}