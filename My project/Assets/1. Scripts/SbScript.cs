using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class SbScript : MonoBehaviour
{
    ProfScript profScript_script;
    SbClass sbClass_script;
    SbClass mySbClass;

    GameObject professor;

    // class info
    public int sbIndex, star;
    new string name;
    string skillName;
    int sbId, atk, sklPower;
    float spd, score;

    // z
    float distance = 10;

    // seonbae position
    int sbPosX, sbPosY;
    int startPosX, startPosY;
    int endPosX, endPosY;

    // distance from character to professor
    float disX, disY;
    float difMousePosY; // difference between mousepos.y and transformpos.y

    Vector3 tilePos; // tile position
    public Tilemap tilemap;

    Animator anim; // atk anim

    // difference between drag and click
    const float INCHTOCM = 2.54f;
    EventSystem eventSystem = null;
    readonly float dragThresholdCm = 0.5f;


    void Start()
    {
        profScript_script = FindObjectOfType<ProfScript>();
        anim = GetComponentInChildren<Animator>();
        professor = GameObject.Find("Professor");
        Idle();

        if(eventSystem == null)
        {
            eventSystem = GetComponent<EventSystem>();
        }
        SetDragThreshold();
    }

    private void SetDragThreshold()
    {
        if(eventSystem != null)
        {
            eventSystem.pixelDragThreshold = (int)(dragThresholdCm*Screen.dpi / INCHTOCM);
        }
    }

    public void GetInfo(SbClass mySbClass)
    {
        sbId = mySbClass.GetId();
        name = mySbClass.GetName();
        score = mySbClass.GetScore();
        skillName = mySbClass.GetSkillName();
        atk = mySbClass.GetAtkPower();
        spd = mySbClass.GetSpeed();
        sklPower = mySbClass.GetSklPower();
        star = mySbClass.GetStar();
    }

    void Update()
    {
        // get prof's tile position
        Vector3 profPos = professor.transform.position;
        int profPosX = (int)profPos.x;
        int profPosY = (int)profPos.y;

        if (profPosX % 2 == 1) profPosX++;
        else if (profPosX % 2 == -1) profPosX--;

        if (profPosX % 4 == 0)
        {
            if (profPosY % 2 == 0) profPosY++;
        }
        else
        {
            if (profPosY % 2 == 1) profPosY++;
            else if (profPosY % 2 == -1) profPosY--;
        }

        Vector3 profTilePos = tilemap.LocalToCell(new Vector3Int(profPosX, profPosY, 0));
        disX = (float)tilePos.x - profTilePos.x;
        disY = (float)tilePos.y - profTilePos.y;

        // y => +-6  x => +-6
        if ((disX >= -6 && disX <= 6) && (disY >= -6 && disY <= 6))
        {
            Attack();
        }
        else
        {
            Idle();
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPosX = sbPosX;
            startPosY = sbPosY;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mouseStartPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            difMousePosY = mouseStartPosition.y - transform.position.y;
        }
    }


    // when drag ends
    void OnMouseUp()
    {
        sbPosX = (int)transform.position.x;
        sbPosY = (int)(transform.position.y);

        if (sbPosX % 2 == 1) sbPosX++;
        else if (sbPosX % 2 == -1) sbPosX--;

        if (sbPosX % 4 == 0)
        {
            if (sbPosY % 2 == 0) sbPosY++;
        }
        else
        {
            if (sbPosY % 2 == 1) sbPosY++;
            else if (sbPosY % 2 == -1) sbPosY--;
        }

        transform.position = new Vector3(sbPosX, sbPosY, 0);

        endPosX = sbPosX;
        endPosY = sbPosY;

        if (endPosX == startPosX && endPosY == startPosY)
        {
            Click();
        }

        tilePos = tilemap.LocalToCell(new Vector3Int(sbPosX, sbPosY, 0));

        // 터치와 드래그 구분
    }

    // sb drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(pos.x, pos.y - difMousePosY, pos.z);
    }

    public void Attack()
    {
        // animation at the spd
        anim.SetBool("isAttack", true);

        // attack when anim is on over
    }

    public void Idle()
    {
        // animtation cancle
        anim.SetBool("isAttack", false);
    }

    public void Click()
    {
        anim.SetBool("isClick", true);
    }

    public void Cancle()
    {
        anim.SetBool("isClick", false);
    }

    public void CantMove()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void CanMove()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}