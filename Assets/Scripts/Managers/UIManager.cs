using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject inGameObjects;

    [SerializeField] private TextMeshProUGUI player1ScoreTxt;
    [SerializeField] private TextMeshProUGUI player2ScoreTxt;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnPlayer1EarnScore += ChangePlayer1ScoreUI;
        EventManager.OnPlayer2EarnScore += ChangePlayer2ScoreUI;
        EventManager.OnGameOver += ShowEndGameUI;
    }

    private void OnDisable()
    {
        EventManager.OnPlayer1EarnScore -= ChangePlayer1ScoreUI;
        EventManager.OnPlayer2EarnScore -= ChangePlayer2ScoreUI;
        EventManager.OnGameOver -= ShowEndGameUI;
    }

    #endregion

    #region Other Methods

    private void ShowEndGameUI()
    {
        inGameUI.SetActive(false);
        endGameUI.SetActive(true);
    }

    private void ShowInGameUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
        inGameObjects.SetActive(true);
    }

    private void ShowMenuUI()
    {
        inGameObjects.SetActive(false);
        endGameUI.SetActive(false);
        menuUI.SetActive(true);
    }

    private void ResetScore()
    {
        player1ScoreTxt.text = "0";
        player2ScoreTxt.text = "0";
    }

    private void ChangePlayer1ScoreUI()
    {
        player1ScoreTxt.text = GameManager.Instance.player1Score.ToString();
    }

    private void ChangePlayer2ScoreUI()
    {
        player2ScoreTxt.text = GameManager.Instance.player2Score.ToString();
    }

    #endregion
}
