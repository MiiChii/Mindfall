using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    private SpriteRenderer _icon;
    
    // Start is called before the first frame update
    void Start()
    {
        _icon = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_icon.enabled == false) return;
        
        if (PlayerInput.Overworld.Interact.WasPressedThisFrame())
        {
            _event.Invoke();
        }
    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        _icon.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        _icon.enabled = false;
    }
}
