using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class ValidateLogin : MonoBehaviour
{
    [SerializeField] TMP_Text errorMessage;

    private const string errorInvalidInput = "無効な入力です";
    private const string errorShortPassword = "パスワードは8文字以上にしてください";

    // メールアドレスのバリデーション
    private bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        if (regex.IsMatch(email) && !ContainsInvalidChars(email) && !IsIpAddress(email))
        {
            return true;
        }
        else
        {
            errorMessage.text = errorInvalidInput;
            return false;
        }
    }

    // 不適切な文字を含むかどうかをチェック
    private bool ContainsInvalidChars(string email)
    {
        string[] invalidChars = { "!", "#", "$", "%", "^", "&", "*", "(", ")", "[", "]", "{", "}", "|", "\\", "/", "<", ">", ",", ";", ":", "'", "\"", "?", "`", "~" };
        foreach (var invalidChar in invalidChars)
        {
            if (email.Contains(invalidChar))
            {
                return true;
            }
        }
        return false;
    }

    // IPアドレスを含むかどうかをチェック
    private bool IsIpAddress(string email)
    {
        string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    // パスワードのバリデーション
    private bool ValidatePassword(string password)
    {
        string pattern = @"^[^\x20-\x7E]*$";
        Regex regex = new Regex(pattern);
        if (password.Length < 8)
        {
            errorMessage.text = errorShortPassword;
            return false;
        }
        else if (!regex.IsMatch(password) || ContainsInvalidChars(password) || IsIpAddress(password))
        {
            errorMessage.text = errorInvalidInput;
            return false;
        }
        return true;
    }

    // バリデーションを実行する関数
    public bool Validate(string whichInput, string inputText)
    {
        switch (whichInput)
        {
            case "Email":
                if (!ValidateEmail(inputText))
                {
                    return false;
                }
                break;
            case "Pass":
                if (!ValidatePassword(inputText))
                {
                    return false;
                }
                break;
            default:
                errorMessage.text = errorInvalidInput;
                return false;
        }
        return true;
    }
}
