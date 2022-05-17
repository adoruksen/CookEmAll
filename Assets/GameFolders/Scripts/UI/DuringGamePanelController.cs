using Assets.GameFolders.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.GameFolders.Scripts.UI
{
    public class DuringGamePanelController : MonoBehaviour
    {
        public static DuringGamePanelController instance;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text moveCounterText;
        public int moveCount;


        void Awake()
        {
            instance = this;
            levelText.text = $"LEVEL {GameManager.Level}";
        }

        void Start()
        {
            moveCount = LevelManager.instance.MoveCounter;
        }
        public void RetryButtonHandle()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MoveCounterSetter(int value)
        {
            moveCounterText.text = $"Move: {value}";
        }

        public void MoveCountDecrease()
        {
            moveCount--;
            moveCounterText.text = $"Move: {moveCount}";
            if (moveCount != 0) return;
            LevelManager.gameState = GameState.Finish;
            CompletePanelController.instance.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
