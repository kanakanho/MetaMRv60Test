using UnityEngine;

public class CopyText : MonoBehaviour
{
    // �R�s�[����e�L�X�g��ێ�����ϐ�
    private string email = "aitkjlb123@email.com";
    private string password = "thisyourpass1234";

    // ���[���A�h���X���N���b�v�{�[�h�ɃR�s�[���郁�\�b�h
    public void CopyEmail()
    {
        // �e�L�X�g���N���b�v�{�[�h�ɃR�s�[����
        GUIUtility.systemCopyBuffer = email;
    }

    // �p�X���[�h���N���b�v�{�[�h�ɃR�s�[���郁�\�b�h
    public void CopyPassword()
    {
        // �e�L�X�g���N���b�v�{�[�h�ɃR�s�[����
        GUIUtility.systemCopyBuffer = password;
    }
}
