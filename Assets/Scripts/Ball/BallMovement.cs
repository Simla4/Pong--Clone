using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 400;

    private int direction = -1;

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

    #endregion

    #region Other Methods

    private void AddStartingForce()
    {
        var yPos = Random.Range(-4.75f, 4.75f);

        transform.position = new Vector3(0, yPos, 0);

        if (direction == -1)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        
        rb.AddForce(new Vector2(speed * direction, speed * direction), ForceMode2D.Force);

        Debug.Log(rb.velocity);
    }

    #endregion
}
