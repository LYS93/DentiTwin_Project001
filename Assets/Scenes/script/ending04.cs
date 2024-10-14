using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending04 : MonoBehaviour
{
    public ending01 endScript;
    Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        //endScript = GetComponent<ending01>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (endScript.isLastMessageDisplayed)
        {
            anima.SetBool("stand", true);
        }
    }
}
