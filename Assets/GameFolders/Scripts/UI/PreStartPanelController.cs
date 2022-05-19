using Assets.GameFolders.Scripts.Managers;
using UnityEngine;

namespace Assets.GameFolders.Scripts.UI
{
    public class PreStartPanelController : MonoBehaviour
    {
        void Awake()
        {
            if (GameManager.Level <= 1) return;
            LevelManager.gameState = GameState.Normal;
            DuringGamePanelController.instance.Activator();
            gameObject.SetActive(false);
        }
        public void GameStarterButton()
        {
            LevelManager.gameState = GameState.Normal;
            gameObject.SetActive(false);
            DuringGamePanelController.instance.Activator();
        }
    }
}
