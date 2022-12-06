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
    [SerializeField] private float speed = 3f;
    [SerializeField] private float yPosLimit = 4f;

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