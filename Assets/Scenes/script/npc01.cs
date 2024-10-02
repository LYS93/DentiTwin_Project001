using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText;

    // Start is called before the first frame update
    void Start()
    {
        npcText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            npcText.enabled = true;
            npcText.text = "��ȭ�� �Ͻ÷��� '�����̽���'�� �����ּ���";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            npcText.enabled = false;
        }
    }
}
