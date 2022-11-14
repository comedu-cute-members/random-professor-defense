using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemButton : MonoBehaviour
{
    Animator anim;
    Button synergyButton;

    GameMenu gameMenu_script;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        synergyButton = GameObject.Find("Synergy").GetComponent<Button>();
        gameMenu_script = FindObjectOfType<GameMenu>();
    }

    void Update()
    {

    }

    public void ClickButton()
    {
        anim.SetBool("isPress", true);
        print("press");
        synergyButton.GetComponent<Button>().interactable = false;
        gameMenu_script.InactiveGameObject();

    }

    public void ClickCancle()
    {
        anim.SetBool("isPress", false);
        synergyButton.GetComponent<Button>().interactable = true;
        gameMenu_script.ActiveGameObject();
    }
}
