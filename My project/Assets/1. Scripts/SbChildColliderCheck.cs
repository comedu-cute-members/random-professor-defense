using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SbChildColliderCheck : MonoBehaviour
{
    bool isUp;

    public bool isCollide = false;
    public GameObject otherSb;

    SbScript sbScript;
    Vector3 startPos;

    void Start()
    {
        sbScript = transform.GetComponentInParent<SbScript>();

        startPos = new Vector3(sbScript.startPosX, sbScript.startPosY, 0);
        // sbScript = parent.GetComponent<SbScript>();

    }

    void Update()
    {
        isUp = sbScript.isUp;
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (isUp)
        {

            if (other.gameObject.tag == "SbFloorCollider")
            {
                //if(other.gameObject.transform.parent.position == transform.parent.position)
                //{
                //    GameObject otherSb = other.transform.parent.gameObject;

                //    sbScript.ChangePos(otherSb);
                //    // change pos by using SbScript
                //    // 문제:
                //    // 바로 위의 부모가 아니라 인스팩터에서 순서대로 선배스크립트 찾아서 적용하는 듯 함
                //}

                isCollide = true;

                otherSb = other.transform.parent.gameObject;
            }
        }
    }
}
