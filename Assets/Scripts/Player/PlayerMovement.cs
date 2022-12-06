using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private playerEnum player;
    [SerializeField] private float speed = 3f;

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
        var posY = transform.localPosition.y;
        
        if (Input.GetKey(playerInputs[0]))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            
        }
        else if (Input.GetKey(playerInputs[1]))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    #endregion
    


    enum playerEnum
    {
        Player1,
        Player2
    }
}
