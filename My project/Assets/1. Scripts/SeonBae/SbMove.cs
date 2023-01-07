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
        print("drag");
        Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        transform.position = MousePosition;
    }

}
