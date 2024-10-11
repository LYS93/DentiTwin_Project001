using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Script : MonoBehaviour
{
    Vector3 teleportLocation = new Vector3(37, -35, 0); // 순간이동할 위치
    Transform P_TR;

    // Start is called before the first frame update
    void Start()
    {
        P_TR = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        if (collider.gameObject.CompareTag("Player"))
        {
            // 플레이어를 순간이동
            P_TR.transform.position = teleportLocation; // Vector3로 순간이동
        }
    }
}
