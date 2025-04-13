using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static Action<PlayerInfo> OnReachFinishLine;
    public static Action OnPauseGame;

    public static bool IsPaused = false;

    [Header("Countdown Screen")]
    [SerializeField] private int _startingCountdownTime;
    [SerializeField] private Transform _countdownPanel;
    [SerializeField] private TMP_Text _startingCountdownText;

    [Header("Pause Menu")]
    [SerializeField] private KeyCode _pauseMenuKey;
    [SerializeField] private Transform _pauseScreen;

    [Header("End Screen")]
    [SerializeField] private Transform _endGameScreen;
    [SerializeField] private TMP_Text _playerNameText;

    private bool _hasFinishedGame = false;
    private float _countdown = 0;

    private void Awake()
    {
        OnReachFinishLine += FinishGame;

        _endGameScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);

        _countdown = _startingCountdownTime;
        TogglePause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_pauseMenuKey) && !_hasFinishedGame)
            TogglePauseMenu();
    }

    private void FixedUpdate()
    {
        if(_countdown == _startingCountdownTime)
        {
            _countdownPanel.gameObject.SetActive(true);
            _startingCountdownText.text = ((int)_countdown).ToString();
            _countdown += 1;
        }

        else if (_countdown > 1)
            _startingCountdownText.text = ((int)_countdown).ToString();

        else if (_countdown < -2)
            return;

        else if (_countdown < 0 && IsPaused)
        {
            _countdownPanel.gameObject.SetActive(false);
            TogglePause();
        }

        else if (_countdown < 1)
            _startingCountdownText.text = "Go!";

        _countdown -= Time.deltaTime;
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
