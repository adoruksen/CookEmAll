using System;
using System.Collections;
using CookEmAll.Managers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CookEmAll.UI
{
    public class CompletePanelController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private GameObject backgroundImg;
        [SerializeField] private GameObject nextLevelButton;
        [SerializeField] private GameObject score;
        [SerializeField] private GameObject layout;

        [Header("Vertical Layout Group")]
        [SerializeField] private GameObject eggPart;
        [SerializeField] private GameObject pancakePart;
        [SerializeField] private GameObject baconPart;
        [SerializeField] private GameObject bagelPart;
        [SerializeField] private GameObject steakPart;


        [NonSerialized] public bool plateMoveFinished;
        private readonly WaitForSeconds shortWaitTime = new(1f);
        private readonly WaitForSeconds longWaitTime = new(1.5f);



        public void NextButtonHandle()
        {

            Initialize.instance.LevelComplete(GameManager.Level);
            GameManager.Level++;

            //SceneLoadLayer.instance.SceneLoadAnimation(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public string SetFinalScoreText(int scoreValue)
        {
            return score.GetComponent<TMP_Text>().text = $"SCORE: {scoreValue}";
        }

        public void Activator(bool condition = true)
        {
            if (!condition) return;
            StartCoroutine(PanelOpenDelay());
        }

        private IEnumerator PanelOpenDelay()
        {
            yield return longWaitTime;
            yield return new WaitUntil(() => plateMoveFinished);
            plateMoveFinished = false;
            BackgroundAnimation();


            VerticalLayoutSetter();
            yield return shortWaitTime;

            score.SetActive(true);
            LayoutElementsAnimation();
            yield return shortWaitTime;
            nextLevelButton.SetActive(true);
        }

        public void BackgroundAnimation()
        {
            backgroundImg.transform.DOScale(1, .5f);
        }

        private void VerticalLayoutSetter()
        {
            if (LevelController.instance.egg) eggPart.SetActive(true);
            if (LevelController.instance.pancake) pancakePart.SetActive(true);
            if (LevelController.instance.bagel) bagelPart.SetActive(true);
            if (LevelController.instance.bacon) baconPart.SetActive(true);
            if (LevelController.instance.steak) steakPart.SetActive(true);
        }

        void LayoutElementsAnimation()
        {
            if (eggPart.activeInHierarchy)
            {
                DOTween.To(() => eggPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount, x=>
                    eggPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = x ,1f, 1f);
            }
            if (pancakePart.activeInHierarchy)
            {
                DOTween.To(() => pancakePart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount, x =>
                    pancakePart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = x, 1f, 1f);
            }
            if (baconPart.activeInHierarchy)
            {
                DOTween.To(() => baconPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount, x =>
                    baconPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = x, 1f, 1f);
            }
            if (bagelPart.activeInHierarchy)
            {
                DOTween.To(() => bagelPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount, x =>
                    bagelPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = x, 1f, 1f);
            }
            if (steakPart.activeInHierarchy)
            {
                DOTween.To(() => steakPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount, x =>
                    steakPart.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = x, 1f, 1f);
            }
        }


        #region Singleton Pattern

        public static CompletePanelController instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
    }
}