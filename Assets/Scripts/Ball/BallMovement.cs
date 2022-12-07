using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManager.OnBallMove += AddStartingForce;
    }

    private void OnDisable()
    {
        EventManager.OnBallMove -= AddStartingForce;
    }

    private void Start()
    {
        AddStartingForce();
    }

    #endregion

    #region Other Methods

    private void AddStartingForce()
    {
        rb.AddForce(new Vector2(300, 300), ForceMode2D.Force);
    }

    #endregion
}
