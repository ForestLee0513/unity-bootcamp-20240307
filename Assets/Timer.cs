using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float time;
    public static bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 멈춰야한다면 정지 처리.
        if (isStop)
        {
            return;
        }

        time += Time.deltaTime;
        // 시간UI 텍스트 갱신
        GameManager.UpdateTimer(time);
    }
}
