using System;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static Action<PlayerInfo> OnReachFinishLine;
    public static Action OnPauseGame;

    public static bool IsPaused = false;

    [SerializeField] private Transform _endGameScreen;
    [SerializeField] private TMP_Text _playerNameText;

    [SerializeField] private KeyCode _pauseMenuKey;
    [SerializeField] private Transform _pauseScreen;

    private bool _hasFinishedGame = false;

    private void Awake()
    {
        OnReachFinishLine += FinishGame;

        _endGameScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_pauseMenuKey))
            TogglePauseMenu();
    }

    private void OnDestroy()
    {
        OnReachFinishLine = null;
        OnPauseGame = null;
    }

    public void TogglePauseMenu()
    {
        _pauseScreen.gameObject.SetActive(!IsPaused);
        TogglePause();
    }

    private void TogglePause()
    {
        if (_hasFinishedGame)
            return;

        IsPaused = !IsPaused;
        OnPauseGame();
    }

    private void FinishGame(PlayerInfo p_winningPlayer)
    {
        TogglePause();
        _hasFinishedGame = true;

        // Show End Screen

        string v_playerName = p_winningPlayer.GetPlayerName();
        _playerNameText.text = v_playerName;
        _endGameScreen.gameObject.SetActive(true);
    }
}
