using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using PlayerInput = Player.PlayerInput;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public float Speed { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveOnInput();
    }
    
    private void MoveOnInput()
    {
        Vector2 moveVector = PlayerInput.Overworld.Movement.ReadValue<Vector2>();

        if (moveVector.magnitude < 0.1f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        GetComponent<Rigidbody2D>().velocity = moveVector * Speed;
    }
}
