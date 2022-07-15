using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameController gameController;
    void Start()
    {
        gameController.OnStateChanged += Move;
    }

    private void Move(GameController.GameState state)
    {
        GetComponent<SplineFollower>().enabled = (state == GameController.GameState.PLAY) ? true : false;
    }
}
