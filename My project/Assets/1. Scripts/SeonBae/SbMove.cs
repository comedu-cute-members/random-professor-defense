using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SbMove : MonoBehaviour
{
    SbScript parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.GetComponentInParent<SbScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        //print("drag");
        parentScript.OnMove();
    }

}
