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
            Debug.Log("되니?");
            GameObject.Find("Teeth").transform.position = new Vector3(30.6f, -2.52f, 0);
            isBackward = false;
            //teeth 오브젝트의 위치값이 지정된 곳으로 옮겨지기.
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
