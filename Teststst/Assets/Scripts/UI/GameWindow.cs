using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

public class GameWindow : MonoBehaviour
{
    [SerializeField] private Button m_StartButton = null;
    [SerializeField] private GameObject m_Content = null;
    [SerializeField] private Text m_StatusLabel = null;

    private GameController m_Game = null;

    private void Awake()
    {
        m_Game = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        m_Content.SetActive(false);
    }

    private void OnGameStarted()
    {
        m_StartButton.gameObject.SetActive(false);
    }

    private void OnGameFinished(bool success)
    {
        m_StatusLabel.text = success ? "Congratulations!" : "Loser!";

        m_Content.SetActive(true);
    }
}
