using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    public void GoToNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
