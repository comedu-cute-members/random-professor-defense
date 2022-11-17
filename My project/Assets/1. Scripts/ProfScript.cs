using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProfScript : MonoBehaviour
{
    // Start is called before the first frame update

    int len;
    float speed;     //professor's  move speed
    List<Vector3> target = new List<Vector3>();
    int n = 1;
    int profAttack;
    int profHp;
    float profSpeed;
    string profName;
    float ypos;
    int axis;
    int c;
    float a, b;
    float A, B, M, N,b1,b2;
    




    void Start()
    {
        Debug.Log("hello");

        //target.Add(new Vector3(8, 7, 0));
        //target.Add(new Vector3(8, 7, 0));
        //target.Add(new Vector3(8, 7, 0));
        //target.Add(new Vector3(8, 7, 0));
        //target.Add(new Vector3(8, 7, 0));
        //target.Add(new Vector3(2, 0, 0));



        //c = (int)target[5].y > (int)target[0].y ? (int)target[5].y : (int)target[0].y;
        //c += 4;
        //A = (float)target[5].x;
        //B = (float)target[5].y;
        //M = (float)target[0].x;
        //N = (float)target[0].y;
        //b1 = (A * (float)Math.Sqrt((double)N - c) - M *(float) Math.Sqrt((double)B - (double)c)) / ((float)Math.Sqrt((double)N - (double)c) - (float)Math.Sqrt((double)B - (double)c));
        //b2 = (A * (float)Math.Sqrt((double)N - c) + M * (float)Math.Sqrt((double)B - (double)c)) / ((float)Math.Sqrt((double)N - (double)c) + (float)Math.Sqrt((double)B - (double)c));
        //if((b1-M)*(b1-A)<0)
        //{
        //    b = b1;
        //}
        //else
        //{
        //    b = b2;
        //}
        //a = (N - c) / ((M - b) * (M - b));
        //Debug.Log("hello");
        //Debug.Log("a="+a);
        //Debug.Log("b=" + b);







    }

    public void GetInfo(ProfClass myProfClass, List<Vector3> route)
    {
        profAttack = myProfClass.GetProfAttack();
        profHp = myProfClass.GetProfHp();
        profSpeed = myProfClass.GetProfSpeed();
        profName = myProfClass.GetProfName();

        target = route;
    }

    void Update()
    {
        Debug.Log("hello");

        {
            // GetDamage(damage);
        }
    }
    void Move()            //move professor
    {
        if (n != target.Count)
        {
            if (transform.position != target[n])
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, target[n], profSpeed);
            }
            if (transform.position == target[n])
            {
                n++;
            }
            Debug.Log(n);


            if (transform.position.x > target[n].x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


  
    public  void GetDamage(int damage)        
    {
        n = 1;
        if (profHp != 0)
        {
            profHp -= damage;
            Debug.Log("HP=" + profHp);
        }
        else
        {
            Debug.Log("±³¼ö »ç¸Á");
        }
    }
}
