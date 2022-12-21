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
                //    // ����:
                //    // �ٷ� ���� �θ� �ƴ϶� �ν����Ϳ��� ������� ���轺ũ��Ʈ ã�Ƽ� �����ϴ� �� ��
                //}

                isCollide = true;

                otherSb = other.transform.parent.gameObject;
            }
        }
    }
}
