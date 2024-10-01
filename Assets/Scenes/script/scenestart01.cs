using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenestart01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //사용자가 스페이스바키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject, 0.5f); // 이 GameObject를 파괴
        }
    }
}
