using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retrun_ToOriginState_Script : MonoBehaviour
{
    bool isBackward = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBackward) 
        {
            Debug.Log("�Ǵ�?");
            GameObject.Find("Teeth").transform.position = new Vector3(30.6f, -2.52f, 0);
            isBackward = false;
            //teeth ������Ʈ�� ��ġ���� ������ ������ �Ű�����.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pushing Object"))
        {
            isBackward = true;
        }
    }
}
