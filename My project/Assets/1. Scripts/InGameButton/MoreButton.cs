using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoreButton : MonoBehaviour
{

    Animator anim;
    GameObject[] childBtns = null;

    int clickCnt = 0;
    int arraySize;

    private void Start()
    {
        arraySize = transform.childCount;
        childBtns = new GameObject[arraySize];

        anim= GetComponent<Animator>();

        for (int i = 0; i < arraySize; i++)
        {
            childBtns[i] = transform.GetChild(i).gameObject;
            childBtns[i].SetActive(false);
        }
    }

    
    public void ClickButton()
    {
        clickCnt++;

        for (int i = 0; i < arraySize; i++)
        {
            print(childBtns[i].name);
        }
        if (clickCnt % 2 == 1)
        {
            anim.SetBool("isPress", true);
            ButtonSetActive();
        }
        else
        {
            anim.SetBool("isPress", false);
            Invoke("ButtonSetActive", 0.3f);
            clickCnt %= 2;
        }
    }

    void ButtonSetActive()
    {
        if (clickCnt % 2 == 1)
        {
            for (int i = 0; i < arraySize; i++)
            {
                childBtns[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < arraySize; i++)
            {
                childBtns[i].SetActive(false);
            }

            clickCnt %= 2;
        }
    }
}
