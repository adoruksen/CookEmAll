using Assets.GameFolders.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace Assets.GameFolders.Scripts.UI
{
    public class CompletePanelController : MonoBehaviour
    {
        [Header("UI Elements")]
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
    }
}
