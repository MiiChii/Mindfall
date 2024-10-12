using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [field: SerializeField] public int Amount { get; set; }
    [field: SerializeField] public Item Item { get; private set; }
}
