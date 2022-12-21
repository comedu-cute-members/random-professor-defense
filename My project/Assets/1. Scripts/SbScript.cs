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
    SbClass sbClass_script;
    SbClass mySbClass;

    SbChildColliderCheck sbChildColliderCheckScript;

    GameObject professor;

    // class info
    int sbIndex, star;
    string sbName;
    string skillName;
    int sbId, atk, sklPower;
    float spd, score;

    // z
    float distance = 10;

    // seonbae position
    public int sbPosX, sbPosY;
    public int startPosX, startPosY;
    public int endPosX, endPosY;

    // distance from character to professor
    float disX, disY;
    float difMousePosY; // difference between mousepos.y and transformpos.y

    Vector3 tilePos; // tile position
    public Tilemap tilemap;

    Animator anim; // atk anim

    // position change
    public bool isUp = true;
    bool isCollide;
    GameObject otherSb;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        professor = GameObject.Find("Professor");
        Idle();

        sbChildColliderCheckScript = GetComponentInChildren<SbChildColliderCheck>();
    }

    public void GetInfo(SbClass mySbClass)
    {
        sbId = mySbClass.GetId();
        sbName = mySbClass.GetName();
        score = mySbClass.GetScore();
        skillName = mySbClass.GetSkillName();
        atk = mySbClass.GetAtkPower();
        spd = mySbClass.GetSpeed();
        sklPower = mySbClass.GetSklPower();
        star = mySbClass.GetStar();

    }

    void Update()
    {
        AttackCheck();
    }

    // touch
    public void OnTouched()
    {
        isUp = false;

        if (Input.GetMouseButtonDown(0))
        {
            startPosX = sbPosX;
            startPosY = sbPosY;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mouseStartPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            difMousePosY = mouseStartPosition.y - transform.position.y;

            print("Touch!!");
        }

    }

    // when drag is end
    public void MouseUpAsButton()
    {
        print("Up!");

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

        endPosX = sbPosX;
        endPosY = sbPosY;

        if (endPosX == startPosX && endPosY == startPosY)
        {
            Click();
        }

        tilePos = tilemap.LocalToCell(new Vector3Int(sbPosX, sbPosY, 0));

        isCollide = sbChildColliderCheckScript.isCollide;
        otherSb = sbChildColliderCheckScript.otherSb;

        if (isCollide)
        {
            ChangePos(otherSb);
        }

        isUp = true;
    }
    

    // sb drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(pos.x, pos.y - difMousePosY, pos.z);
    }

    /// <����>
    /// 1. ��ǥ�� ��ġ�� �ٲ�� ������µ� ������ �巡�� �߿��� ��ǥ�� ��ġ�� �Ǵ� ������ Ȯ���� ��ġ�� �ڹٲ�� ��
    /// 2. �� ���� �ǵ���� �ص� �ٲ��� ����
    /// </����>
    /// 
    /// <�ذ�å>
    /// 1. DirectorScript���� ��� ������Ʈ���� �巡�� �Ǵ� �� �����ϰ� ���� ��ǥ�� �� ��ǥ�� �� �� �ִٸ� �� �� ������? ==> ��ȿ����
    /// 2. ���콺 Ŭ���� ������ bool�� ������ ���� � ������Ʈ�� ���������� Ȯ���ϴ� ��
    /// 3. if ���콺 �巡�׵Ǹ鼭 �ٰ��� ������Ʈ�� ���� �ε����ٸ� ==> sbchildcollidercheck ��ũ��Ʈ���� bool�� �ڷ� ���� Ȯ��
    /// </�ذ�å>

    public void ChangePos(GameObject otherSb)
    {
        if(otherSb.transform.position == transform.position)
        {
            Vector3 temp = otherSb.transform.position;
            otherSb.transform.position = new Vector3(startPosX, startPosY, 0);
            transform.position = temp;
            print("isChange");
        }
    }


    private void AttackCheck()
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