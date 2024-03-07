using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPrefs : MonoBehaviour
{
    public GameObject usernameField;
    public GameObject passwordField;

    public void SignIn()
    {
        string usernameInputValue = usernameField.GetComponent<InputField>().text;
        string passwordInputValue = passwordField.GetComponent<InputField>().text;

        // 모든 input 값이 있을 때
        if (usernameInputValue != null && passwordInputValue != null)
        {
            bool isUsernameSame = usernameInputValue == PlayerPrefs.GetString("username");
            bool isPasswordSame = passwordInputValue == PlayerPrefs.GetString("password");
            // prefs에서의 값과 인풋의 값이 모두 일치할 때 출력.
            if(isUsernameSame && isPasswordSame)
            {
                Debug.Log("Sign in success");
            }
            else
            {
                Debug.Log("User info is incorrect.");
            }
        }
    }

    public void SignUp()
    {
        string usernameInputValue = usernameField.GetComponent<InputField>().text;
        string passwordInputValue = passwordField.GetComponent<InputField>().text;

        // 모든 input 값이 있을 때
        if (usernameInputValue != null && passwordInputValue != null)
        {
            // prefs에서 username 검색 후 기존의 유저와 같으면 가입취소 처리
            if (PlayerPrefs.GetString("username") == usernameInputValue)
            {
                Debug.Log("This user is alreay exists.");
                return;
            }

            PlayerPrefs.SetString("username", usernameInputValue);
            PlayerPrefs.SetString("password", passwordInputValue);

            Debug.Log("Sign up success");
        }
    }
}
