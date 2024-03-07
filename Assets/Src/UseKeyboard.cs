using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseKeyboard : MonoBehaviour
{
    // �O������InputField�̌Ăяo��
    [SerializeField] private TMP_InputField inputEmailField;

    [SerializeField] private string OutputEmail;

    // �O������InputField�̌Ăяo��
    [SerializeField] private TMP_InputField inputPassField;

    [SerializeField] private string OutputPass;

    public bool isPass = false;
    public bool isEmail = false;

    // �L�[�{�[�h�̐錾
    private TouchScreenKeyboard _overlayKeyboard;

    [SerializeField] ValidateLogin m_ValidateLogin;

    private void Start()
    {
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
    }

    // �L�[�{�[�h�̕ύX���ɓ���
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

    // Email�p�̃L�[�{�[�h���Ăяo���֐�
    public void SetEmailKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(OutputEmail, TouchScreenKeyboardType.URL);
        isPass = false;
        isEmail = true;
    }

    // Pass�p�̃L�[�{�[�h���Ăяo���֐�
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
