namespace PotionCraft.Models.Ingredients
{
    public class Ingredient: IIngredient
    {
        public IngredientId Id { get; }
        
        public Ingredient(IngredientId id)
        {
            Id = id;
        }
    }
}