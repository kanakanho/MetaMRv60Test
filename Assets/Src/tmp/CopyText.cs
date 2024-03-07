using UnityEngine;

public class CopyText : MonoBehaviour
{
    // コピーするテキストを保持する変数
    private string email = "aitkjlb123@email.com";
    private string password = "thisyourpass1234";

    // メールアドレスをクリップボードにコピーするメソッド
    public void CopyEmail()
    {
        // テキストをクリップボードにコピーする
        GUIUtility.systemCopyBuffer = email;
    }

    // パスワードをクリップボードにコピーするメソッド
    public void CopyPassword()
    {
        // テキストをクリップボードにコピーする
        GUIUtility.systemCopyBuffer = password;
    }
}
