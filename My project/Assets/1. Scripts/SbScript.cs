using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class SbScript : MonoBehaviour
{
    public int sbIndex;

    public Tilemap tilemap;
    DirectorScript directorScript_script;
    SbClass sbClass_script;
    SbClass mySbClass;

    new string name;
    string skillName;
    int sbId, atk, sklPower;
    float spd, score;

    float distance = 10;

    int characterPosX, characterPosY;

    Animator anim;
    GameObject coll;

    void Start()
    {
        directorScript_script = FindObjectOfType<DirectorScript>();
        anim = GetComponent<Animator>();
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

    }


    // store drag point
    private void OnMouseUp()
    {
        characterPosX = (int)transform.position.x;
        characterPosY = (int)transform.position.y;

        if (characterPosX % 2 == 1) characterPosX++;
        else if (characterPosX % 2 == -1) characterPosX--;

        if (characterPosX % 4 == 0)
        {
            if (characterPosY % 2 == 0) characterPosY++;
        }
        else
        {
            if (characterPosY % 2 == 1) characterPosY++;
            else if (characterPosY % 2 == -1) characterPosY--;
        }

        transform.position = new Vector3(characterPosX, characterPosY, 0);

        Vector3 pos = tilemap.LocalToCell(new Vector3Int(characterPosX, characterPosY, 0));
        print(pos.x);
        print(pos.y);
        print("=========");
    }

    // sb drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = pos;
    }

    // enemy is in collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            coll = collision.gameObject;

            // start attack
            anim.SetBool("isAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        coll = null;

        // end attack

    }

    private void Attack()
    {
        
    }
}
