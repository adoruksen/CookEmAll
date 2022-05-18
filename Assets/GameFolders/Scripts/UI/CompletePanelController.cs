using Assets.GameFolders.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.GameFolders.Scripts.UI
{
    public class CompletePanelController : MonoBehaviour
    {
        public static CompletePanelController instance;
        void Awake()
        {
            instance=this;
        }

        public void WinStatusOpener()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void LoseStatusOpener()
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
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
    }
}
