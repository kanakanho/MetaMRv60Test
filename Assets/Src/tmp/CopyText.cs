using UnityEngine;

public class CopyText : MonoBehaviour
{
    // コピーするテキストを保持する変数
    private string email = "";
    private string password = "";

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
