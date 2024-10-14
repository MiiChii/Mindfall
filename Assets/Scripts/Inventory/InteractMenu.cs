using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class InteractMenu : MonoBehaviour 
{
    [field: SerializeField] private Button _useButton;
    [field: SerializeField] private Button _examineButton;
    [field: SerializeField] private Button _discardButton;
    [field: SerializeField] private Button _swapButton;
    [field: SerializeField] private Button _moveButton;

    public InventorySlot CurrentSlot { get; private set; }
    private bool _swapping;

    void Start()
    {
        _swapping = false;
    }


    


    public void Interact(InventorySlot slot)
    {
        if (_swapping)
        {
            _swapping = false;
            Debug.Log(CurrentSlot + " + " + slot);
            (slot.ItemContainer, CurrentSlot.ItemContainer) = (CurrentSlot.ItemContainer, slot.ItemContainer);

            Select(null);
            return;
        }


        if (slot.Item == null)
        {
            Select(null);
            return;
        }
        

        _useButton.gameObject.SetActive(slot.Item.Usable);
        _discardButton.gameObject.SetActive(!slot.Item.Important);
        
        Select(slot);
    }

    public void Select(InventorySlot slot)
    {
        CurrentSlot = slot;
        gameObject.SetActive(slot);
    }
    
    
    
    public void Use()
    {
        
    }
    
    
    public void Discard()
    {
        CurrentSlot.ItemContainer = new ItemContainer();
        Select(null);
    }
    
    public void Examine()
    {
        ItemExamineDisplay.Instance.DisplayItem(CurrentSlot.Item);
        Select(null);
    }
    
    public void Swap()
    {
        _swapping = true;
        gameObject.SetActive(false);
    }
}
