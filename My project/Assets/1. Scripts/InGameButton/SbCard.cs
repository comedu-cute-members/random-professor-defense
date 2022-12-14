using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SbCard : MonoBehaviour
{

    public GameObject sbPref;

    List<Vector2> posList;

    private void Start()
    {
        posList = new List<Vector2>();

        // add posList (-8, -15) (-6, -16) (-10, -16) (-8, -17) (-6, -18) (-10, -18) (-8, -19)
        posList.Add(new Vector2(-8, -15));
        posList.Add(new Vector2(-6, -16));
        posList.Add(new Vector2(-10, -16));
        posList.Add(new Vector2(-8, -17));
        posList.Add(new Vector2(-6, -18));
        posList.Add(new Vector2(-10, -18));
        posList.Add(new Vector2(-8, -19));

    }
    public void OnClick() 
    {
        Destroy(gameObject);

        InstantiatePref();
    }

    private void InstantiatePref()
    {
        for(int i = 0; i < 7; i++) 
        {

        }
    }
}
