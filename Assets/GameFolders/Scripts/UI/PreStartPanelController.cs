using CookEmAll.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CookEmAll.UI
{
    public class PreStartPanelController : MonoBehaviour
    {
        void Start()
        {
            Initialize.instance.LevelStart(GameManager.Level);
            if (GameManager.Level <= 1) return;
            gameObject.SetActive(false);
            GetComponent<Button>().enabled = false;
            LevelManager.gameState = GameState.Normal;
            DuringGamePanelController.instance.Activator();
        }
        public void GameStarterButton()
        {
            Initialize.instance.LevelStart(GameManager.Level);
            LevelManager.gameState = GameState.Normal;
            gameObject.SetActive(false);
            TutorialPanelController.instance.Activator();
            //DuringGamePanelController.instance.Activator();
        }
    }
}
