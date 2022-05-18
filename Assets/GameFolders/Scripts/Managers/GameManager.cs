using UnityEngine;

namespace Assets.GameFolders.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        static int level;
        public static int Level
        {
            get
            {
                if (!PlayerPrefs.HasKey("level"))
                {
                    return 1;
                }
                return PlayerPrefs.GetInt("level");
            }
            set
            {
                level = value;
                PlayerPrefs.SetInt("level", level);
            }
        }

        private void Awake()
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                PlayerPrefs.SetInt("level", 1);
            }
        }
    }
}
