using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfScript : MonoBehaviour
{
    // Start is called before the first frame update

    int hp = 5000;
    public int attack;
    int len;
    public float speed;     //professor's  move speed
    public int x1, y1;      //target1 x, y coordinate
    public int x2, y2;      //target2 x, y coordinate
    public int x3, y3;      //target3 x, y coordinate
    public int x4, y4;      //target4 x, y coordinate
    List<Vector3> target = new List<Vector3>();
    int n = 0;
  



    void Start()
    {
        len = 4;
        Debug.Log("len = "+len);
        target.Add(new Vector3(x1, y1, 0));
        target.Add(new Vector3(x2, y2, 0));
        target.Add(new Vector3(x3, y3, 0));
        target.Add(new Vector3(x4, y4, 0));
        if (n == len)
        {
            GetDamage(attack);
        }
    }
    void Update()
    {
        Move();
        if (hp <= 0)
        {

        }
    }
    void Move()            //move professor
    {
        if (n != len)
        {
            if (transform.position != target[n])
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, target[n], speed);
            }
            if (transform.position == target[n])
            {        
              n++;          
            }
        }
    }

    void GetDamage(int damage)        
    {
        if (hp != 0)
        {
            hp -= damage;
            Debug.Log("HP=" + hp);
        }
           else
        {
            Debug.Log("±³¼ö »ç¸Á");
        }
    }
}
