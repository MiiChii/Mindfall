using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public InventorySlot[] Slots { get; private set; }
    
    [field: SerializeField] private GameObject _textBox;
    [field: SerializeField] private TMP_Text _nameText;
    [field: SerializeField] private TMP_Text _descriptionText;
    
    [field: SerializeField] private GameObject _container;
    
    // Start is called before the first frame update
    void Start()
    {
        _container.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Overworld.OpenInventory.WasPressedThisFrame())
        {
            PlayerInput.Overworld.Disable();
            PlayerInput.Inventory.Enable();
            _container.SetActive(true);
        }

        if (PlayerInput.Inventory.CloseInventory.WasPressedThisFrame())
        {
            CloseInventory();
        }
    }

    public void CloseInventory()
    {
        PlayerInput.Overworld.Enable();
        PlayerInput.Inventory.Disable();
        _container.SetActive(false);
    }

    private bool AddItem(Item item)
    {
        foreach (InventorySlot s in Slots)
        {
            if (s.Item == item && s.Amount + 1 <= s.Item.MaxStack)
            {
                s.Amount++;
                return true;
            }
        }

        foreach (InventorySlot s in Slots)
        {
            if (s.Item != null) continue;
            
            s.Item = item;
            s.Amount++;
            return true;
        }

        Debug.Log("INVENTORY FULL"); // TODO
        return false;
    }

    public void Add(Item item)
    {
        AddItem(item);
    }

    public void Add(Pickup pickup)
    {
        while (AddItem(pickup.Item))
        {
            if (--pickup.Amount == 0)
            {
                Destroy(pickup.gameObject);
                break;
            }
        }
    }
    

    public void Move(Inventory other)
    {
        
    }

    public void DisplayText(InventorySlot slot)
    {
        if (slot.Item == null)
        {
            RemoveText();
            return;
        }
        
        _textBox.SetActive(true);
        _nameText.text = slot.Item.Name;
        _descriptionText.text = slot.Item.Description;
    }

    public void RemoveText()
    {
        
        
        _textBox.SetActive(false);
        _nameText.text = "";
        _descriptionText.text = "";
    }
    
    
}
