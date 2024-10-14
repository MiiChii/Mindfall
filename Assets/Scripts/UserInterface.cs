using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Player.PlayerInput;

public class UserInterface : MonoBehaviour
{
    [field: SerializeField] public GameObject Background { get; private set; }
    private Stack<GameObject> _openMenus;
    
    public static UserInterface Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        _openMenus = new Stack<GameObject>();
    }


    void Update()
    {
        if (PlayerInput.Inventory.CloseInventory.WasPressedThisFrame())
        {
            CloseMenu();
        }
    }


    public void OpenMenu(GameObject container)
    {
        if (_openMenus.Count == 0)
        {
            Background.SetActive(true);
            PlayerInput.ChangeInputSystem(PlayerInput.InputSystem.Inventory);
        }
        else
            _openMenus.Last().SetActive(false);
        
        container.SetActive(true);
        _openMenus.Push(container);
    }

    public void CloseMenu()
    {
        _openMenus.Pop().SetActive(false);
        
        if (_openMenus.Count == 0)
        {
            Background.SetActive(false);
            PlayerInput.ChangeInputSystem(PlayerInput.InputSystem.Overworld);
            return;
        }

        _openMenus.Last().SetActive(true);
    }
}


