using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public InventorySlot[] Slots { get; private set; }
    [field: SerializeField] private InteractMenu _interactMenu;
    
    [field: SerializeField] private GameObject _textBox;
    [field: SerializeField] private TMP_Text _nameText;
    [field: SerializeField] private TMP_Text _descriptionText;
    
    [field: SerializeField] private GameObject _container;
    
    // Start is called before the first frame update
    void Awake()
    {
        _interactMenu.Select(null);
        _container.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Overworld.OpenInventory.WasPressedThisFrame())
        {
            UserInterface.Instance.OpenMenu(_container);
        }
        
        if (_container.activeSelf == false && (_interactMenu.gameObject.activeSelf || _textBox.activeSelf))
        {
            _interactMenu.Select(null);
            RemoveText();
        }
    }
    
    
    

    private bool AddItem(Item item)
    {
        foreach (InventorySlot s in Slots)
        {
            if (s != null && s.Item == item && s.Amount + 1 <= s.Item.MaxStack)
            {
                s.Amount++;
                return true;
            }
        }

        foreach (InventorySlot s in Slots)
        {
            if (s == null || s.Item != null) continue;
            
            s.Item = item;
            s.Amount++;
            return true;
        }

        Debug.Log("INVENTORY FULL"); // TODO
        return false;
    }

    public void Add(ItemContainer item)
    {
        while (AddItem(item.Item))
        {
            if (--item.Amount == 0)
            {
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
        if (_interactMenu.CurrentSlot != null)
        {
            DisplayText(_interactMenu.CurrentSlot);
            return;
        }
        
        _textBox.SetActive(false);
        _nameText.text = "";
        _descriptionText.text = "";
    }
    
    
}
