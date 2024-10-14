using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;




public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private ItemContainer _itemContainer;

    public ItemContainer ItemContainer
    {
        get => _itemContainer ??= new ItemContainer();
        
        set
        {
            _itemContainer = value;
            Amount = value.Amount;
            Item = value.Item;
        }
        
    }
    
    private Image _image;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Sprite empty;
    
    [SerializeField] private Inventory _inventory;
    
    public int Amount
    {
        get => ItemContainer.Amount;
        set
        {
            ItemContainer.Amount = value;
            
            if (value > 1) amountText.text = value.ToString();
            else amountText.text = "";
        } 
    }
    
    
    public Item Item
    {
        get => ItemContainer.Item;
        set
        {
            _image ??= GetComponent<Image>();
            
            ItemContainer.Item = value;
            _image.sprite = (value != null) ? ItemContainer.Item.Icon : empty; 
        }
    }
    
    
    
    
    
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        _inventory.DisplayText(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        _inventory.RemoveText();
    }
}
