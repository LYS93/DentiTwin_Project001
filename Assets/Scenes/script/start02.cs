using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start02 : MonoBehaviour
{
    private void Awake()
    {
        // 이 오브젝트가 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

}
