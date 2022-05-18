using Assets.GameFolders.Scripts.Managers;
using UnityEngine;

namespace Assets.GameFolders.Scripts.UI
{
    public class PreStartPanelController : MonoBehaviour
    {
        public void GameStarterButton()
        {
            LevelManager.gameState = GameState.Normal;
            gameObject.SetActive(false);
            DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive((true));
        }
    }
}
