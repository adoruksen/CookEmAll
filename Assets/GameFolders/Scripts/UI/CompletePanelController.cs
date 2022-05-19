using Assets.GameFolders.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using DG.Tweening;

namespace Assets.GameFolders.Scripts.UI
{
    public class CompletePanelController : MonoBehaviour
    {
        [Header("UI Elements")] [SerializeField]
        private GameObject backgroundImg;
        [SerializeField] GameObject levelCompletedText;
        [SerializeField] GameObject nextLevelButton;
        [SerializeField] GameObject score;
        [SerializeField] GameObject coin;

        WaitForSeconds waitTime = new WaitForSeconds(.5f);

        #region Singleton Pattern
        public static CompletePanelController instance;
        void Awake()
        {
            instance=this;
        }
        #endregion



        public void NextButtonHandle()
        {
            GameManager.Level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneLoadLayer.instance.SceneLoadAnimation(false);

        }

        public void TryAgainButtonHandle()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Activator(bool condition = true)
        {
            if (!condition) return;
            BackgroundAnimation();
            levelCompletedText.GetComponent<TMP_Text>().text = $"Level {GameManager.Level} Completed";
            StartCoroutine(PanelOpenDelay());
        }

        IEnumerator PanelOpenDelay()
        {
            yield return waitTime;

            levelCompletedText.SetActive(true);
            yield return waitTime;

            score.SetActive(true);
            coin.SetActive(true);

            yield return waitTime;
            nextLevelButton.SetActive(true);
        }

        public void BackgroundAnimation(/*bool isStart = true*/)
        {
            backgroundImg.SetActive(true);
            backgroundImg.transform.DOScale(1, .5f);

            //if (isStart)
            //{
            //    backgroundImg.transform.localScale = new Vector2(75, 75);
            //    backgroundImg.transform.DOScale(0, 1);
            //}
            //else
            //{
            //}
        }
    }
}
