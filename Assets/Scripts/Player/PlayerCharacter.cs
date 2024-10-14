using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerMovement _movement;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    public Inventory Inv { get; private set; }
    private ItemGun _gun; // TODO: REMOVE
    
    // Start is called before the first frame update
    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        Inv = GetComponent<Inventory>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Overworld.Shoot.IsPressed())
        {
            if (_gun == null)
            {
                foreach (InventorySlot s in Inv.Slots)
                {
                    if (s.Item != null && s.Item.Name == "Bertha") _gun = (ItemGun)s.Item;
                }

                //_gun._isOnCooldown = false;
                
                if (_gun == null)
                {
                    Debug.Log("No Weapon equipped");
                } // TODO: MOVE GUN MANAGEMENT TO INVENTORY AND SHOOT INPUT TO SHOOT SCRIPT

                return;
            }

            StartCoroutine(_gun.Shoot(transform.position, Vector2.right));



        }
    }


    public void SetCharacter(bool state)
    {
        _movement.enabled = state;
        _col.enabled = state;
        _rb.simulated = state;
        Inv.enabled = state;
    }
}
