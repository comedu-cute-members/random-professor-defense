using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SbScript : MonoBehaviour
{
    public int sbIndex;
    DirectorScript directorScript_script;

    float atk;
    float spd;
    float skill;
    float distance = 10;


    // Start is called before the first frame update
    void Start()
    {
        sbIndex = UnityEngine.Random.Range(0, 29);
        directorScript_script = FindObjectOfType<DirectorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sb Drag
    void OnMouseDrag()
    {
        Vector3 moustposition = new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(moustposition);
        transform.position = objPosition;
    }

}
