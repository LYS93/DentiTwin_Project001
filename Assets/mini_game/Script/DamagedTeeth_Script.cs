using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedTeeth_Script : MonoBehaviour
{
    public float Jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pushing Object"))
        {
            transform.Translate(0, Jump * Time.deltaTime , 0);
        }
    }
}
