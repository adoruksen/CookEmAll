using CookEmAll.Gameplay.Controllers;
using CookEmAll.Managers;
using UnityEngine;

namespace CookEmAll.UI
{
    public class TutorialPanelController : MonoBehaviour
    {
        private InputController inputController;
        public static TutorialPanelController instance;

        void Awake()
        {
            instance = this;
            inputController = new InputController();
        }
        void Update()
        {
            if (LevelManager.gameState == GameState.Normal)
            {
                if (inputController.FingerTap)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}

