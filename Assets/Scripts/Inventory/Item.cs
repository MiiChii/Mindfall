using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: Multiline]
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    
    [field: Space]
    
    [field: SerializeField] public int MaxStack { get; private set; }
    [field: SerializeField] public bool Usable { get; private set; }
    [field: SerializeField] public bool Important { get; private set; }
    
    [field: Space]
    [field: SerializeField] public Sprite ExamineImage { get; private set; }
}
