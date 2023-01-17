using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProfScript : MonoBehaviour
{
    // Start is called before the first frame update

    int len;
    float speed;     //professor's  move speed
    public List<Vector3> target = new List<Vector3>();
    public int n = 1;
    public int profAttack = 500;
    public int profHp=100;
    float profSpeed = 10f;
    string profName;
    int rotSpeed;
    Rigidbody2D rb;
    GameObject profS;
    public int i = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        rotSpeed = 0;
        profS = GameObject.Find("ProfessorSprite");
        target.Add(new Vector3(-8, 7, 0));  //Start position
        target.Add(new Vector3(0, 3, 0));
        target.Add(new Vector3(5, 0, 0));
        target.Add(new Vector3(4, -1, 0));
        target.Add(new Vector3(2, -2, 0));       //destination
        target.Add(new Vector3(0, -1, 0));     //senegi position
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
        if (n != target.Count-1)
        {
            Move();
        }

        if (Math.Abs(transform.position.x) > 8)
        {
            rb.bodyType = RigidbodyType2D.Static;
            rotSpeed = 0;
            profS.transform.localEulerAngles = new Vector3(0, 0, 0);
            n = 0;
            i = 0;
        }
        profS.transform.Rotate(0, 0, this.rotSpeed*Time.deltaTime);
        if(profHp<0)
        {
            
        }
     
    }
    void Move()            //move professor to destination
    {
   
            if (transform.position != target[n])
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, target[n], profSpeed*Time.deltaTime);
            }
             if (transform.position == target[n])
             {
                 n++;
             }
        
        //Debug.Log(n);
        if (transform.position.x > target[n].x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Kicked(Vector3 dir)
    {
        if (i == 0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(dir);
            if (target[0].x > target[target.Count - 1].x)
                rotSpeed = -2000;
            else
                rotSpeed = 2000;
            profHp -= 30;
        }
        i++;
        
    }
    public  void GetDamage(int damage)
    { 
        profHp -= damage;      
    }
}
