using System.Collections;
using System.Collections.Generic;
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
