using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGoal;
    private static GameManager instance = null;
    private static GameObject TimerText;
    private static GameObject ResultScreen;
    private static GameObject highScoreText;
    private static GameObject resultTimeText;
    private static int highScore = 0;

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Initialize all Components //
    void Init()
    {
        // Initialize UI //
        if (GameObject.Find("UICanvas/Timer") != null)
        {
            TimerText = GameObject.Find("UICanvas/Timer");
        }

        if(GameObject.Find("UICanvas/Result") != null)
        {
            ResultScreen = GameObject.Find("UICanvas/Result");

            // highScoreText 필드 적용
            if(GameObject.Find("UICanvas/Result/BestTimeText"))
            {
                highScoreText = GameObject.Find("UICanvas/Result/BestTimeText");
            }
            // resultTime 필드 적용
            if (GameObject.Find("UICanvas/Result/ResultTimeText"))
            {
                resultTimeText = GameObject.Find("UICanvas/Result/ResultTimeText");
            }

            ResultScreen.SetActive(false);
        }
        // Initialize PlayerPrefs //
        // Create HighScore if it is not extists.
        if(PlayerPrefs.HasKey("HighScore") == false)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        // Load HighScore
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        Init();
    }

    // Timer Manage //
    static public void ToggleGoal()
    {
        if(isGoal)
        {
            // 타이머 재시작 처리
            isGoal = false;
            Timer.isStop = false;
            ResultScreen.SetActive(false);
        }
        else
        {
            // 타이머 정지 처리
            isGoal = true;
            Timer.isStop = true;
            ResultScreen.SetActive(true);
        }

        SetHighScore();
    }

    public static void UpdateTimer(float time)
    {
        TimerText.GetComponent<TextMeshProUGUI>().text = Mathf.Floor(time).ToString();
    }

    // Score Manage //
    public static void SetHighScore()
    {
        if(Timer.time < highScore || highScore == 0)
        {
            highScore = Convert.ToInt32(Mathf.Floor(Timer.time));
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateHighScore();
    }

    static void UpdateHighScore()
    {

        highScoreText.GetComponent<TextMeshProUGUI>().text = $"Best Time: {highScore}";
        resultTimeText.GetComponent<TextMeshProUGUI>().text = $"Result Time: {Mathf.Floor(Timer.time)}";
    }

    // Scene Manage //
    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ToggleGoal();
    }
}
