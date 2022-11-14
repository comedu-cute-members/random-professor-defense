using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SynergyButton : MonoBehaviour
{
    Animator anim;
    Button itemButton;

    GameMenu gameMenu_script;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        itemButton = GameObject.Find("Item").GetComponent<Button>();
        gameMenu_script = FindObjectOfType<GameMenu>();
    }

    void Update()
    {
        
    }

    public void ClickButton()
    {
        anim.SetBool("isPress", true);
        print("press");
        itemButton.GetComponent<Button>().interactable = false;
        gameMenu_script.InactiveGameObject();

    }

    public void ClickCancle()
    {
        anim.SetBool("isPress", false);
        itemButton.GetComponent<Button>().interactable = true;
        gameMenu_script.ActiveGameObject();

    }
}
