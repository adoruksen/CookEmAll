using System.Collections;
using System.Collections.Generic;
using Assets.GameFolders.Scripts.Managers;
using Assets.GameFolders.Scripts.UI;
using UnityEngine;

public class PreStartPanelController : MonoBehaviour
{
    public void GameStarterButton()
    {
        LevelManager.gameState = GameState.Normal;
        gameObject.SetActive(false);
        DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive((true));
    }
}
