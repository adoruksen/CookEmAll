using Assets.GameFolders.Scripts.Managers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.GameFolders.Scripts.UI
{
    public class DuringGamePanelController : MonoBehaviour
    {
        public static DuringGamePanelController instance;
        [SerializeField] private GameObject retryButton;
        [SerializeField] private TMP_Text levelText;

        [SerializeField] private TMP_Text coinText;
         //[SerializeField] private TMP_Text moveCounterText;
        //public int moveCount;


        void Awake()
        {
            instance = this;
            levelText.text = $"LEVEL {GameManager.Level}";
            coinText.text = $"{GameManager.Coin}";
        }

        //void Start()
        //{
        //    moveCount = LevelManager.instance.MoveCounter;
        //}
        public void RetryButtonHandle()
        {
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
            levelText.text = $"Level {GameManager.Level}";
            levelText.transform.parent.gameObject.SetActive(true);
            coinText.transform.parent.gameObject.SetActive(true);
        }
        //public void MoveCounterSetter(int value)
        //{
        //    moveCounterText.text = $"Move: {value}";
        //}

        //public void MoveCountDecrease()
        //{
        //    moveCount--;
        //    moveCounterText.text = $"Move: {moveCount}";
        //    if (moveCount != 0) return;
        //    LevelManager.gameState = GameState.Finish;
        //    //CompletePanelController.instance.transform.GetChild(1).gameObject.SetActive(true); about Move Counter
        //}
    }
}
