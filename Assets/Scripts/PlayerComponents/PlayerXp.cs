using UnityEngine;

namespace PlayerComponents
{
    public class PlayerXp : PlayerComponent
    {
        [SerializeField] private int initialXpRequirement = 5;
        [SerializeField] private float incrementScale = 0.5f;

        public static int CurrentXpAmount;
        public static int AmountToNextLevel;
        public static int CurrentLevel;

        private void Start()
        {
            NextLevel();
            Player.OnXp += PlayerOnXp;
        }

        private void PlayerOnXp()
        {
            CurrentXpAmount++;

            if (CurrentXpAmount > AmountToNextLevel)
            {
                NextLevel();
            }
        }

        private void NextLevel()
        {
            CurrentXpAmount = 0;
            CurrentLevel++;
            AmountToNextLevel = (int)(initialXpRequirement * CurrentLevel * incrementScale);
        }
    }
}