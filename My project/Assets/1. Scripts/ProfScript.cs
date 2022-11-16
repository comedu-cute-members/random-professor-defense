using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfScript : MonoBehaviour
{
    // Start is called before the first frame update

    int len;
    float speed;     //professor's  move speed
    public int x1, y1;      //target1 x, y coordinate
    public int x2, y2;      //target2 x, y coordinate
    public int x3, y3;      //target3 x, y coordinate
    public int x4, y4;      //target4 x, y coordinate
    List<Vector3> target = new List<Vector3>();
    int n = 0;
    int profAttack;
    int profHp;
    float profSpeed;
    string profName;
   



    void Start()
    {
       
        target.Add(new Vector3(x1, y1, 0));
        target.Add(new Vector3(x2, y2, 0));
        target.Add(new Vector3(x3, y3, 0));
        target.Add(new Vector3(x4, y4, 0));
      
        
    }

    public void GetInfo(ProfClass myProfClass)
    {
        profAttack = myProfClass.GetProfAttack();
        profHp = myProfClass.GetProfHp();
        profSpeed = myProfClass.GetProfSpeed();
        profName = myProfClass.GetProfName();
    }

    void Update()
    {
        Move();
        if (n == target.Count)
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

    void GetDamage(int damage)        
    {
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
