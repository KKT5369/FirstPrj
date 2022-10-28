using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    private static string _nextScene;

    public static void LoadScene(string sceneName)
    {
        _nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    
    void Start()
    {
        StartCoroutine("LoadSceneProcess");
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(_nextScene);
        // 로딩상황을 90%에서 멈춘다
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress > 0.8f)
            {
                yield return new WaitForSeconds(3f);
                yield return op.allowSceneActivation = true;
            }
        }
    }
}
