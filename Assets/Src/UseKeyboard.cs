using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseKeyboard : MonoBehaviour
{
    // 外部からInputFieldの呼び出し
    [SerializeField] private TMP_InputField inputEmailField;

    [SerializeField] private string OutputEmail;

    // 外部からInputFieldの呼び出し
    [SerializeField] private TMP_InputField inputPassField;

    [SerializeField] private string OutputPass;

    public bool isPass = false;
    public bool isEmail = false;

    // キーボードの宣言
    private TouchScreenKeyboard _overlayKeyboard;

    [SerializeField] ValidateLogin m_ValidateLogin;

    private void Start()
    {
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
    }

    // キーボードの変更時に動く
    private void Update()
    {
        if (_overlayKeyboard.text == "") return;

        // email
        if (isEmail)
        {
            inputEmailField.text = _overlayKeyboard.text;
            OutputEmail = inputEmailField.text;
        }

        // pass
        if (isPass)
        {
            inputPassField.text = _overlayKeyboard.text;
            OutputPass = inputPassField.text;
           
        }

    }

    // Email用のキーボードを呼び出す関数
    public void SetEmailKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(OutputEmail, TouchScreenKeyboardType.URL);
        isPass = false;
        isEmail = true;
    }

    // Pass用のキーボードを呼び出す関数
    public void SetPassKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(OutputPass, TouchScreenKeyboardType.URL);
        isPass = true;
        isEmail = false;
    }

    public void CleanInoutText(string whichInput)
    {
        switch (whichInput)
        {
            case ("Email"):
                {
                    inputEmailField.text = "";
                    break;
                }
            case ("Pass"):
                {
                    inputPassField.text = "";
                    break;
                }
            default:
                inputEmailField.text = "";
                inputPassField.text = "";
                break;
        }
    }
}
