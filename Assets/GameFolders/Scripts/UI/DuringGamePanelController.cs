using CookEmAll.Managers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CookEmAll.UI
{
    public class DuringGamePanelController : MonoBehaviour
    {
        public static DuringGamePanelController instance;
        [SerializeField] private GameObject retryButton;
        [SerializeField] private TMP_Text levelText;

        [SerializeField] private TMP_Text coinText;
        [SerializeField] private TMP_Text moveCounterText;
        public int moveCount;


        void Awake()
        {
            instance = this;
            levelText.text = $"LEVEL {GameManager.Level}";
            coinText.text = $"{GameManager.Coin}";
        }

        void Start()
        {
            moveCount = LevelController.instance.moveCounter;
            moveCounterText.text = $"MOVE:{moveCount}";
        }
        public void RetryButtonHandle()
        {
            LevelManager.gameState = GameState.BeforeStart;
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void UpdateCoin(int amount)
        {
            var before = GameManager.Coin;
            GameManager.Coin += amount;
            DOTween.To(() => before, x => before = x, GameManager.Coin, 1).OnUpdate(() => coinText.text = before + string.Empty);
        }

        public void Activator()
        {
            retryButton.SetActive(true);
            levelText.text = $"LEVEL {GameManager.Level}";
            levelText.transform.parent.gameObject.SetActive(true);
            coinText.transform.parent.gameObject.SetActive(true);
            moveCounterText.gameObject.SetActive(true);
        }
        public void MoveCounterSetter(int value)
        {
            moveCounterText.text = $"MOVE: {value}";
        }

        public void MoveCountDecrease()
        {
            moveCount--;
            moveCounterText.text = $"MOVE: {moveCount}";
            if (moveCount <= 0)
            {
                LevelManager.gameState = GameState.Finish;
            }
            //CompletePanelController.instance.transform.GetChild(1).gameObject.SetActive(true); about Move Counter
        }
    }
}
