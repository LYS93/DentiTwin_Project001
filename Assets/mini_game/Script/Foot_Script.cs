using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_Script : MonoBehaviour
{
    Player_Script PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("Player").GetComponent<Player_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
           PS.isJump = false;
        }
    }
}
