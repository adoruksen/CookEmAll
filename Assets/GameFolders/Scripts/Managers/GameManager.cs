using UnityEngine;

namespace CookEmAll.Managers
{
    public class GameManager : MonoBehaviour
    {
        static int level;
        public static int Level
        {
            get => !PlayerPrefs.HasKey("level") ? 1 : PlayerPrefs.GetInt("level");
            set
            {
                level = value;
                PlayerPrefs.SetInt("level", level);
            }
        }

        static int coin;
        public static int Coin
        {
            get => PlayerPrefs.GetInt("coin");
            set
            {
                coin = value;
                PlayerPrefs.SetInt("coin", coin);
            }
        }

        private void Awake()
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                PlayerPrefs.SetInt("level", 1);
            }
            if (!PlayerPrefs.HasKey("coin"))
            {
                PlayerPrefs.SetInt("coin", 0);
            }
        }
    }
}
