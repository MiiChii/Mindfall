using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class ItemExamineDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public static ItemExamineDisplay Instance { get; private set; }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayItem(Item item)
    {
        _image.sprite = item.ExamineImage;
        UserInterface.Instance.OpenMenu(gameObject);
    }

    public void HideDisplay()
    {
        UserInterface.Instance.CloseMenu();
    }
}
