using System.Collections;
using Assets.GameFolders.Scripts.Managers;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LosePanelController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject backgroundImage;
    [SerializeField] GameObject tryAgainImg;
    [SerializeField] GameObject emoji;
    [SerializeField] GameObject tryAgainButton;

    WaitForSeconds waitTime = new WaitForSeconds(.5f);

    #region Singleton Pattern
    public static LosePanelController instance;
    void Awake()
    {
        instance = this;
    }
    #endregion


    public void TryAgainButtonHandle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneLoadLayer.instance.SceneLoadAnimation(false);
    }

    public void Activator(bool condition = true)
    {
        if (!condition) return;
        backgroundImage.SetActive(true);
        StartCoroutine(PanelOpenDelay());
    }

    IEnumerator PanelOpenDelay()
    {
        yield return waitTime;

        tryAgainImg.SetActive(true);
        yield return waitTime;

        emoji.SetActive(true);
        tryAgainButton.SetActive(true);
    }
}

