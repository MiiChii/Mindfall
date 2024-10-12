using UnityEngine;
using UnityEngine.UI;


public class InteractMenu : MonoBehaviour 
{
    [field: SerializeField] private Button _useButton;
    [field: SerializeField] private Button _examineButton;
    [field: SerializeField] private Button _discardButton;
    [field: SerializeField] private Button _swapButton;
    [field: SerializeField] private Button _moveButton;

    private InventorySlot _slot;
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
                
            (slot.Item, _slot.Item) = (_slot.Item, slot.Item);
            (slot.Amount, _slot.Amount) = (_slot.Amount, slot.Amount);
            _slot = null;
            
            return;
        }


        if (slot.Item == null) return;
        

        _useButton.interactable = slot.Item.Usable;
        _discardButton.interactable = !slot.Item.Important;
        
        _slot = slot;
        gameObject.SetActive(true);
    }
    
    
    
    public void Use()
    {
        
    }
    
    
    public void Discard()
    {
        _slot.Item = null;
        _slot.Amount = 0;
        gameObject.SetActive(false);
    }
    
    public void Examine(Image examineImage)
    {
        examineImage.sprite = _slot.Item.ExamineImage;
        examineImage.enabled = true;
        gameObject.SetActive(false);
    }
    
    public void Swap()
    {
        _swapping = true;
        gameObject.SetActive(false);
    }
}
