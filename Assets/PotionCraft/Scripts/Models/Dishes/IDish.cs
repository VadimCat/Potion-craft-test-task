using PotionCraft.Models.Dishes.Naming;
using PotionCraft.Models.Dishes.Scoring;
using PotionCraft.Models.Ingredients;

namespace PotionCraft.Models.Dishes
{
    public interface IDish
    {
        IDishName Name { get; }
        IDishScore Score { get; }
        IngredientsMix Ingredients { get; }
    }
}