using CookEmAll.Gameplay.Controllers;
using CookEmAll.Managers;
using UnityEngine;

namespace CookEmAll.UI
{
    public class TutorialPanelController : MonoBehaviour
    {
        private InputController inputController;
        public static TutorialPanelController instance;
        [SerializeField] GameObject hand;
        [SerializeField] GameObject background;
        [SerializeField] GameObject tutorialMessage;

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
                    if (GameManager.Level==1)
                    {
                        DuringGamePanelController.instance.Activator();
                    }
                }
            }
        }
        public void Activator()
        {
            hand.SetActive(true);
            background.SetActive(true); 
            tutorialMessage.SetActive(true);    
        }
    }
}

