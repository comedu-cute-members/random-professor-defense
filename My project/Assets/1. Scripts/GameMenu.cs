using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour
{
    public Button btn;

    Animator anim;
    GameObject[] seonbae;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
       
    }

    public void InactiveGameObject()
    {
        seonbae = GameObject.FindGameObjectsWithTag("Seonbae");
        for (int i = 0; i < seonbae.Length; i++)
        {
            seonbae[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void ActiveGameObject()
    {
        for (int i = 0; i < seonbae.Length; i++)
        {
            seonbae[i].GetComponent<BoxCollider2D>().enabled=true;
        }
    }

    // 버튼 이벤트 관리 어디서 할지 고민 중

    //public void ClickButton()
    //{
    //    anim.SetBool("isPress", true);
    //    print("press");
    //}

    //public void ClickSynergyButton()
    //{
    //    anim.SetBool("isSynergyPress", true);
    //}

    //public void ClickCancle()
    //{
    //    anim.SetBool("isPress", false);
    //}
}
