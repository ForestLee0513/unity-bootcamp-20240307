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
        // ���� ������Ѵٸ� ���� ó��.
        if (isStop)
        {
            return;
        }

        time += Time.deltaTime;
        // �ð�UI �ؽ�Ʈ ����
        GameManager.UpdateTimer(time);
    }
}
