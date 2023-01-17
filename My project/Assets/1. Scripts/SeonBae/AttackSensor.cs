using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSensor : MonoBehaviour
{

    SbScript parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.parent.GetComponent<SbScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Professor")
        {
            parentScript.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Professor")
        {
            parentScript.Idle();
        }
    }
}
