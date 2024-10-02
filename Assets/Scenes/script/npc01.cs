using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText;
    public GameObject talkScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            talkScreen.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = true;
            npcText.text = "대화를 하시려면 '스페이스바'를 눌러주세요";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkScreen.SetActive(true);
            }            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = false;            
        }
    }
}
