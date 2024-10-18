using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_ToOriginState_Script : MonoBehaviour
{
    Transform T_TR;

    // Start is called before the first frame update
    void Start()
    {
        T_TR = GameObject.Find("Teeth").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pushing Object"))
        {
            T_TR.transform.position = new Vector3(30.6f, -2.52f, 0);
        }
    }
}
