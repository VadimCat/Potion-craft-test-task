namespace PotionCraft.Models.Dishes.Scoring
{
    public class DishScore : IDishScore
    {
        public int Score { get; }
        public static IDishScore Default => new DishScore(0);

        public DishScore(int score)
        {
            Score = score;
        }
    }
}