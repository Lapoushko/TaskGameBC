using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isCanMoving = false;
    public event Action<GameState> OnStateChanged;
    public event Action<int> OnCountPlayerChanged;

    public static GameController Instance;

    public GameState State { get => state; set { state = value; OnStateChanged?.Invoke(state); } }
    private GameState state;

    public int countPlayer;
    public int CountPlayer { get => countPlayer; set { countPlayer = value; OnCountPlayerChanged?.Invoke(countPlayer); } }

    public GameObject spline;
    public enum GameState
    {
        START,
        PLAY,
        FINISH,
        GAME_OVER
    };
    public void StartGame()
    {
        State = GameState.PLAY;
        isCanMoving = true;
    }
    private void Awake()
    {
        Instance = this;
    }
    public void FinishGame()
    {
        State = GameState.FINISH;
        isCanMoving = false;
    }
    public void LoseGame()
    {
        State = GameState.GAME_OVER;
        isCanMoving = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
