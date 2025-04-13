using System;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static Action<PlayerInfo> OnReachFinishLine;
    public static bool IsPlayingGame = true;

    [SerializeField] private Transform _endGameScreen;
    [SerializeField] private TMP_Text _playerNameText;

    private void Awake()
    {
        OnReachFinishLine += FinishGame;
    }

    private void OnDestroy()
    {
        OnReachFinishLine = null;
    }

    private void FinishGame(PlayerInfo p_winningPlayer)
    {
        IsPlayingGame = false;

        // Show End Screen

        string v_playerName = p_winningPlayer.GetPlayerName();
        _playerNameText.text = v_playerName;
        _endGameScreen.gameObject.SetActive(true);
    }
}
