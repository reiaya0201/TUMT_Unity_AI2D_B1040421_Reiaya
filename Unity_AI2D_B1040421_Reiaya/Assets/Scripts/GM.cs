using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public void Replay()
    {
        //讀取場景
        SceneManager.LoadScene("Game");
    }

    public void End()
    {
        //關掉遊戲
        Application.Quit();
    }
}
