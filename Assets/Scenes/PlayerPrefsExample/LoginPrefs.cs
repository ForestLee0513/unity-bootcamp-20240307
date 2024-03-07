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

        // ��� input ���� ���� ��
        if (usernameInputValue != null && passwordInputValue != null)
        {
            bool isUsernameSame = usernameInputValue == PlayerPrefs.GetString("username");
            bool isPasswordSame = passwordInputValue == PlayerPrefs.GetString("password");
            // prefs������ ���� ��ǲ�� ���� ��� ��ġ�� �� ���.
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

        // ��� input ���� ���� ��
        if (usernameInputValue != null && passwordInputValue != null)
        {
            // prefs���� username �˻� �� ������ ������ ������ ������� ó��
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
