using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    #region Variables

    [SerializeField] private PlayerMovement playerMovement;

    public int player1Score = 0;
    public int player2Score = 0;

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

    public void StartGame()
    {
        Time.timeScale = 1;
        EventManager.OnBallMove?.Invoke();
    }

    private void ChangePleyer1Score()
    {
        player1Score++;
        
        if (player1Score == 10)
        {
            GameOver();
        }
    }
    private void ChangePleyer2Score()
    {
        player2Score++;
        
        if (player2Score == 10)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        EventManager.OnGameOver?.Invoke();
    }

    private void GameWithOnePlayer()
    {
        playerMovement.isAI = true;
        playerMovement.speed = 4;
    }

    public void RetryGame()
    {
        player1Score = 0;
        player2Score = 0;
        
        Time.timeScale = 1;
        EventManager.OnBallMove?.Invoke();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
