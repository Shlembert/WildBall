using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneLoad(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
