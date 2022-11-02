using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class SbScript : MonoBehaviour
{
    public int sbIndex;

    DirectorScript directorScript_script;
    SbClass sbClass_script;
    SbClass mySbClass;

    new string name;
    string skillName;
    int sbId, atk, sklPower;
    float spd, score;

    float distance = 10;



    void Start()
    {
        directorScript_script = FindObjectOfType<DirectorScript>();
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
    private void OnMouseDown()
    {
        Vector3 clickPoint = Input.mousePosition;
    }

    // sb drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = pos;
    }

}
