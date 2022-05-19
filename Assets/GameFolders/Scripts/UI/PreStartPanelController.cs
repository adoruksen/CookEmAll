using Assets.GameFolders.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameFolders.Scripts.UI
{
    public class PreStartPanelController : MonoBehaviour
    {
        void Start()
        {
            if (GameManager.Level <= 1) return;
            gameObject.SetActive(false);
            GetComponent<Button>().enabled = false;
            LevelManager.gameState = GameState.Normal;
            DuringGamePanelController.instance.Activator();
        }
        public void GameStarterButton()
        {
            LevelManager.gameState = GameState.Normal;
            gameObject.SetActive(false);
            DuringGamePanelController.instance.Activator();
        }
    }
}
