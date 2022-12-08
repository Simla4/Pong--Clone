using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI player1ScoreTxt;
    [SerializeField] private TextMeshProUGUI player2ScoreTxt;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnPlayer1EarnScore += ChangePlayer1ScoreUI;
        EventManager.OnPlayer2EarnScore += ChangePlayer2ScoreUI;
    }

    private void OnDisable()
    {
        EventManager.OnPlayer1EarnScore -= ChangePlayer1ScoreUI;
        EventManager.OnPlayer2EarnScore -= ChangePlayer2ScoreUI;
    }

    #endregion

    #region Other Methods

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
