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
        //����ڰ� �����̽���Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject, 0.5f); // �� GameObject�� �ı�
        }
    }
}
