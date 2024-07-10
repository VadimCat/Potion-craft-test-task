namespace PotionCraft.Models.Ingredients
{
    public interface ICauldron: IDishPublisher
    {
        void AddIngredient(IIngredient ingredient);
        IngredientsMix Ingredients { get; }
    }
}