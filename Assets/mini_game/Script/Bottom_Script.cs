using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Script : MonoBehaviour
{
    Vector3 teleportLocation = new Vector3(37, -35, 0); // �����̵��� ��ġ
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
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (collider.gameObject.CompareTag("Player"))
        {
            // �÷��̾ �����̵�
            P_TR.transform.position = teleportLocation; // Vector3�� �����̵�
        }
    }
}
