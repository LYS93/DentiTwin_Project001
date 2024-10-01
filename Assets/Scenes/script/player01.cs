using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01 : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public float playerSpeed;
    Animator playerAnima;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnima = GetComponent<Animator>();
        playerAnima.SetBool("right", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //playerAnima.SetBool("right", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.fixedDeltaTime * playerSpeed, 0, 0);
            playerSprite.flipX = false;
            playerAnima.SetBool("right", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnima.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Time.fixedDeltaTime * playerSpeed, 0, 0);
            playerSprite.flipX = true;
            playerAnima.SetBool("right", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnima.SetBool("right", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, Time.fixedDeltaTime * playerSpeed, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -Time.fixedDeltaTime * playerSpeed, 0);
        }
    }
}
