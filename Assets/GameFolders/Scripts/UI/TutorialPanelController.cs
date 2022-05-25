using Assets.GameFolders.Scripts.Gameplay.Controllers;
using Assets.GameFolders.Scripts.Managers;
using UnityEngine;

public class TutorialPanelController : MonoBehaviour
{
    public static TutorialPanelController instance;

    void Awake()
    {
        instance = this;
    }
    [SerializeField] private InputController inputController;
    void Update()
    {
        if (LevelManager.gameState==GameState.Normal)
        {
            if (inputController.FingerTap)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
