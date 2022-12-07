using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player1"))
        {
            EventManager.OnPlayer2EarnScore?.Invoke();
            ResetBall();
        }

        if (col.gameObject.CompareTag("Player2"))
        {
            EventManager.OnPlayer1EarnScore?.Invoke();
            ResetBall();
        }
    }

    private void ResetBall()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.SetActive(true);
        EventManager.OnBallMove?.Invoke();
    }
}
