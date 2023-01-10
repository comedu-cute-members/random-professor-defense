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
    Vector3 currentPos;

    public Tilemap tilemap;
    string mouseState = "up";
    Vector3 distanceY;
    GameObject samePosOther = null;

    Animator anim; // atk anim

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        currentPos = transform.position;
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

    private void OnMouseDown()
    {
        print(sbIndex);
        distanceY = Camera.main.ScreenToWorldPoint(Input.mousePosition) - currentPos;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - distanceY;
        mouseState = "drag";
    }

    private void OnMouseUp()
    {
        if (mouseState == "drag")
        {
            if (samePosOther)
            {
                samePosOther.transform.position = currentPos;
                samePosOther.GetComponent<SbScript>().OnMoveByOther();
                samePosOther = null;
            }

            // move position to tile
            int sbPosX = (int)transform.position.x;
            int sbPosY = (int)transform.position.y;

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
            currentPos = transform.position;
        }
        mouseState = "up";
        distanceY = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Seonbae")
        {
            samePosOther = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Seonbae")
        {
            samePosOther = null;
        }
    }

    void OnMoveByOther()
    {
        currentPos = transform.position;
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