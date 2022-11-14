using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using System.Diagnostics;

public class SbScript : MonoBehaviour
{
    public int sbIndex;

    public Tilemap tilemap;
    DirectorScript directorScript_script;
    SbClass sbClass_script;
    SbClass mySbClass;

    GameObject professor;

    new string name;
    string skillName;
    int sbId, atk, sklPower;
    float spd, score;

    // for drag or touch
    float touchStartTime, touchEndTime;

    // z
    float distance = 10;

    int sbPosX, sbPosY;
    // distance from character to professor
    float disX, disY;

    Vector3 tilePos;

    Animator anim;

    Stopwatch sw = new Stopwatch();
    void Start()
    {
        directorScript_script = FindObjectOfType<DirectorScript>();
        anim = GetComponent<Animator>();
        professor = GameObject.Find("Professor");
        Idle();
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

        // test
        if (Input.GetMouseButtonUp(0))
        {
            print(profPosX);
            print(profPosY);
            print(profTilePos);
            print("===============");
            print(tilePos);
        }
    }


    // when drag ends
    void OnMouseUp()
    {
        sbPosX = (int)transform.position.x;
        sbPosY = (int)transform.position.y;

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

        tilePos = tilemap.LocalToCell(new Vector3Int(sbPosX, sbPosY, 0));
        
        print("=========");

        sw.Stop();
        
        // 터치와 드래그 구분
    }

    // sb drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = pos;

        sw.Start();
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


}
