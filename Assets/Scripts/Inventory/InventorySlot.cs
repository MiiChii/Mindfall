using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;




public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;
    private Button _button;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Sprite empty;
    [SerializeField] private Inventory _inventory;

    public int _amount;
    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            
            if (value > 1) amountText.text = value.ToString();
            else amountText.text = "";
        } 
    }
    
    
    private Item _item;
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            _image.sprite = (value != null) ? _item.Icon : empty; 
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
