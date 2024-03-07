using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerPrefsExample2 : MonoBehaviour
{
    PlayerData playerData;

    public GameObject NameInput;
    public GameObject AgeInput;
    public GameObject HightInput;

    private void Start()
    {
        if(playerData == null)
        {
            playerData = gameObject.AddComponent<PlayerData>();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", NameInput.GetComponent<InputField>().text);
        PlayerPrefs.SetInt("PlayerAge", Convert.ToInt32(AgeInput.GetComponent<InputField>().text));
        PlayerPrefs.SetInt("PlayerHight", Convert.ToInt32(HightInput.GetComponent<InputField>().text));
    }

    //진짜지나자니자ㅣ자 가능하면 매니저로 관리하자..
    public void LoadData()
    {
        playerData.name = PlayerPrefs.GetString("PlayerName");
        playerData.age = PlayerPrefs.GetInt("PlayerAge");
        playerData.hight = PlayerPrefs.GetInt("PlayerHight");

        UpdateInput();
    }

    void UpdateInput()
    {
        NameInput.GetComponent<InputField>().text = playerData.name;
        AgeInput.GetComponent<InputField>().text = playerData.age.ToString();
        HightInput.GetComponent<InputField>().text = playerData.hight.ToString();
    }
}
