using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSwitcher : MonoBehaviour
{
    [field: SerializeField] public PlayerCharacter CharacterCurrent { get; private set; }
    [field: SerializeField] public PlayerCharacter CharacterOther { get; private set; }
    
    
    public static PlayerSwitcher Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        CharacterCurrent.SetCharacter(true);
        CharacterOther.SetCharacter(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Overworld.SwitchCharacter.WasPressedThisFrame())
        {
            CharacterCurrent.SetCharacter(false);
            
            (CharacterCurrent, CharacterOther) = (CharacterOther, CharacterCurrent);

            CharacterCurrent.SetCharacter(true);

        }
    }
}
