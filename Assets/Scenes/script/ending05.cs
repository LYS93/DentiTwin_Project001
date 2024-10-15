using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending05 : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-2*Time.deltaTime, 0, 0);

        if(transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }
    }
}
