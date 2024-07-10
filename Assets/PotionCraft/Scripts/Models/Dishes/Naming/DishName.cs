namespace PotionCraft.Models.Dishes.Naming
{
    public class DishName: IDishName
    {
        public string Name { get; }
        public static DishName Default => new DishName(string.Empty);

        public DishName(string name)
        {
            Name = name;
        }
    }
}