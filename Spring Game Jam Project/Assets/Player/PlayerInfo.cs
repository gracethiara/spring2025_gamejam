using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private string _playerName;

    public string GetPlayerName()
    {
        return _playerName;
    }
}
