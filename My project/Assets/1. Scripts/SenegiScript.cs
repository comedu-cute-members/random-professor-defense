using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SenegiScript : MonoBehaviour
{
    //public GameObject ProfScript;
    public GameObject prof;
    public GameObject target;

    //List<Vector3> target = new List<Vector3>();
    public int x;
    public int y;
    public int time = 1;
    public int Hp = 1000;
    public int dir;
    Animator animator;
   


    // Start is called before the first frame update
    void Start()
    { 
        prof = GameObject.Find("Professor");
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (prof.transform.position == prof.GetComponent<ProfScript>().target[4])
        {
            Turn();
            time++;
            Hp --;
            if (time ==200)
            {
                time = 0;
                prof.GetComponent<ProfScript>().Kicked(new Vector3(x, y, 0));
                this.animator.SetTrigger("KickTrigger"); 
                Rotate(dir);
            }
                    
        }
        if (Hp<0)
        {
            Destroy(gameObject);
        }
    }

    void Turn()
    {
        if (transform.position.x > prof.GetComponent<ProfScript>().target[4].x)
        {
            transform.localScale = new Vector3(0.1410064f, 0.1398337f, 1);
            dir = -1;
        }
        else
        {
            transform.localScale = new Vector3(-0.1410064f, 0.1398337f, 1);
            dir = 1;
        }
    }

    void Rotate(int dir)
    {
    //    for (int i = 0; i < 10; i++)
      //  {
        transform.Rotate(0, 0, dir * 5);
        //}
        //for (int i = 0; i < 10; i++)
        //{
        //   transform.Rotate(0, 0, dir * -5);
        //}
    }
}
