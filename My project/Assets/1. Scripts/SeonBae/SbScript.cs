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
    SbClass mySbClass;

    // class info
    int sbIndex;

    public Tilemap tilemap;

    Animator anim; // atk anim

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        Idle();
    }

    public void GetInfo(int sbIndex, SbClass sbClass)
    {   
        this.sbIndex = sbIndex;
        mySbClass = sbClass;
    }

    void Update()
    {

    }

    private void OnMouseDrag()
    {
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        transform.position = Camera.main.ScreenToWorldPoint(mousePoint);
        print(Camera.main.ScreenToWorldPoint(mousePoint));
    }

    public void OnMove()
    {
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        transform.position = Camera.main.ScreenToWorldPoint(mousePoint);
        print(Camera.main.ScreenToWorldPoint(mousePoint));
    }

    /************ anim****************/
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