using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [field: SerializeField] public ItemContainer Item { get; private set; }
    
    
    public void AddToCurrentCharacter()
    {
        Item.AddToCurrentCharacter();
    }
    
    public void AddToOtherCharacter()
    {
        Item.AddToOtherCharacter(); 
    }
    
}