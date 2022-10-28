using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField userId;
    public InputField userPs;
    public Button loginBtn;

    public void LoginBtnClick()
    {
        var id = userId.text;
        var ps = userPs.text;
        
        Debug.Log($"ID >> {id} Ps >> {ps} 으로 로그인!!");
        LoadingController.LoadScene("GameScene");
    }
}
