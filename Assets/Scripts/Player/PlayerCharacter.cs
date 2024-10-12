using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerMovement _movement;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    
    // Start is called before the first frame update
    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetCharacter(bool state)
    {
        _movement.enabled = state;
        _col.enabled = state;
        _rb.simulated = state;
    }
}
