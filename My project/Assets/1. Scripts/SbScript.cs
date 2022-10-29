using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SbScript : MonoBehaviour
{
    public int sbIndex;

    DirectorScript directorScript_script;
    SbClass sbClass_script;

    string name, skillName;
    int atk, sklPower;
    float spd, score;

    float distance = 10;

    void Start()
    {
        sbIndex = UnityEngine.Random.Range(0, 29);

        directorScript_script = FindObjectOfType<DirectorScript>();
        sbClass_script = GetComponent<SbClass>();
    }

    void GetClassInfo()
    {
        name = sbClass_script.GetName();
        score = sbClass_script.GetScore();
        skillName = sbClass_script.GetSkillName();
        atk = sbClass_script.GetAtkPower();
        spd = sbClass_script.GetSpeed();
        sklPower = sbClass_script.GetSklPower();

    }

    void Update()
    {
        
    }

    // Sb Drag
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 worldObjectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = worldObjectPosition;
    }

}
