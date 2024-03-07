using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class ValidateLogin : MonoBehaviour
{
    [SerializeField] TMP_Text errorMessageEmail;
    [SerializeField] TMP_Text errorMessagePassword;

    private const string errorInvalidInput = "�����ȓ��͂ł�";
    private const string errorNotMatchEmail = "���[���A�h���X�������ł�";
    private const string errorShortPassword = "�p�X���[�h��8�����ȏ�ɂ��Ă�������";
    private const string errorYouNotUseJapanese = "�p�X���[�h�ɂ͓��{����܂߂邱�Ƃ͂ł��܂���";

    // �s�K�؂ȕ������܂ނ��ǂ������`�F�b�N
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

    // IP�A�h���X���܂ނ��ǂ������`�F�b�N
    private bool IsIpAddress(string email)
    {
        string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    // ����̕�������֎~
    private bool ContainsSpecialMeaning(string email)
    {
        string[] specialStrings = { "admin", "root", "superuser", "administrator", "system", "guest", "test", "password", "123456", "qwerty", "admin123", "root123" }; // ����ȈӖ�����������̃��X�g
        foreach (var specialString in specialStrings)
        {
            if (email.ToLower().Contains(specialString))
            {
                return true;
            }
        }
        return false;
    }

    // ���{����܂ނ��ǂ������`�F�b�N
    private bool ContainsJapanese(string password)
    {
        // ���{����܂ނ��ǂ����̐��K�\���p�^�[��
        string pattern = @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(password);
    }

    // ���[���A�h���X�̃o���f�[�V����
    public bool ValidateEmail(string email)
    {
        string pattern = @"^([a-zA-Z0-9._%+-]+@)?[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        // ���[���A�h���X�̌`���`�F�b�N
        if (!regex.IsMatch(email))
        {
            ValidateErrorEmail(errorNotMatchEmail);
            return false;
        }
        if (ContainsInvalidChars(email))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        if (ContainsSpecialMeaning(email))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        if (IsIpAddress(email))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        return true;
    }

    // �p�X���[�h�̃o���f�[�V����
    public bool ValidatePassword(string password)
    {
        if (password.Length < 8)
        {
            ValidateErrorPassword(errorShortPassword);
            return false;
        }
        if (ContainsJapanese(password))
        {
            ValidateErrorEmail(errorYouNotUseJapanese);
            return false;
        }
        if (ContainsInvalidChars(password))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        if (ContainsSpecialMeaning(password))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        if (IsIpAddress(password))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        return true;
    }

    public void ValidateErrorEmail(string errorText)
    {
        errorMessageEmail.text = errorText;
    }

    public void ValidateErrorPassword(string errorText)
    {
        errorMessagePassword.text = errorText;
    }
}
