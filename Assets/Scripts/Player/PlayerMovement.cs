using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private playerEnum player;
    [SerializeField] private float yPosLimit = 4f;
    [SerializeField] private GameObject ball;

    public bool isAI = false;
    public float speed = 3f;
    
    
    
    private List<KeyCode> playerInputs = new List<KeyCode>();

    #endregion

    #region Callbacks

    private void Start()
    {
        if (player == playerEnum.Player2)
        {
            playerInputs.Add(KeyCode.UpArrow);
            playerInputs.Add(KeyCode.DownArrow);
        }
        else if(player == playerEnum.Player1)
        {
            playerInputs.Add(KeyCode.S);
            playerInputs.Add(KeyCode.X);
        }
    }

    private void Update()
    { 
        MovePlayer();
    }

    #endregion

    #region Other Methods

    private void MovePlayer()
    {
        var pos = transform.localPosition;

        if (isAI == true)
        {
            if (ball.transform.position.x < -1)
            {
                pos.y = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, Time.deltaTime * speed);
                var newPos = Mathf.Clamp(pos.y, -yPosLimit, yPosLimit);
                transform.localPosition = new Vector3(pos.x, newPos, pos.z);
            }
        }
        
        if (Input.GetKey(playerInputs[0]))
        {
            pos.y += speed * Time.deltaTime;
            var newPos = Mathf.Clamp(pos.y, -yPosLimit, yPosLimit);
            transform.localPosition = new Vector3(pos.x, newPos, pos.z);

        }
        else if (Input.GetKey(playerInputs[1]))
        {
            pos.y += -speed * Time.deltaTime;
            var newPos = Mathf.Clamp(pos.y, -yPosLimit, yPosLimit);
            transform.localPosition = new Vector3(pos.x, newPos, pos.z);
        }
    }

    #endregion


    enum playerEnum
    {
        Player1,
        Player2
    }
}
