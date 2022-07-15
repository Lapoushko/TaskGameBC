using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameController gameController;
    public DudeController dudeController;
    public GameObject startMenu;
    public GameObject loseMenu;
    public GameObject finishMenu;

    private void Start()
    {
        gameController.OnStateChanged += UpdateUI;
        //dudeController = GetComponent<DudeController>();
    }

    private void UpdateUI(GameController.GameState state)
    {
        startMenu.SetActive(state == GameController.GameState.START);
        loseMenu.SetActive(state == GameController.GameState.GAME_OVER);
        if (dudeController.Count <= 0)
        {
            state = GameController.GameState.GAME_OVER;
        }
        finishMenu.SetActive(state == GameController.GameState.FINISH);
    }
}
