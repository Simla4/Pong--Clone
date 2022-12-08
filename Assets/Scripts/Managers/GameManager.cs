using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    #region Variables

    public int player1Score = 1;
    public int player2Score = 1;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnPlayer1EarnScore += ChangePleyer1Score;
        EventManager.OnPlayer2EarnScore += ChangePleyer2Score;
    }

    private void OnDisable()
    {
        EventManager.OnPlayer1EarnScore -= ChangePleyer1Score;
        EventManager.OnPlayer2EarnScore -= ChangePleyer2Score;
    }

    #endregion

    #region Other Methods

    private void ChangePleyer1Score()
    {
        player1Score++;
        
        if (player1Score > 10)
        {
            Debug.Log("Player 1 Win!");
        }
    }
    private void ChangePleyer2Score()
    {
        player2Score++;
        
        if (player2Score > 10)
        {
            Debug.Log("Player 2 Win!");
        }
    }

    #endregion
}
