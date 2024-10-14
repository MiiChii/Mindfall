using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemContainer
{
    [field: SerializeField] public Item Item { get; set; }
    [field: SerializeField] public int Amount { get; set; }


    public void AddToCurrentCharacter()
    {
        PlayerSwitcher.Instance.CharacterCurrent.Inv.Add(this);
    }
    
    public void AddToOtherCharacter()
    {
        PlayerSwitcher.Instance.CharacterOther.Inv.Add(this);
    }
}
