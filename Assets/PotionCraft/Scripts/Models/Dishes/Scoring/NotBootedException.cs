using System;

namespace PotionCraft.Models.Dishes.Scoring
{
    public class NotBootedException : Exception
    {
        public NotBootedException() : base("Bootstrapping is required before using. Call Bootstrap() first.")
        {
        }
    }
}