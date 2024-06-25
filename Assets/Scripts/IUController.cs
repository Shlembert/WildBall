using UnityEngine;

public class IUController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;

    public void PressButton(ButtonType buttonType)
    {
        switch (buttonType)
        {
            case ButtonType.Play:
                Play();
                break;
            case ButtonType.Pause:
                Pause();
                break;
            case ButtonType.MainMenu:
                MainMenu();
                break;
            case ButtonType.Setting:
                Setting();
                break;
            case ButtonType.Level_1:
                sceneController.SceneLoad(1);
                break;
            case ButtonType.Level_2:
                sceneController.SceneLoad(2);
                break;
            case ButtonType.Level_3:
                sceneController.SceneLoad(3);
                break;
            case ButtonType.Level_4:
                sceneController.SceneLoad(4);
                break;
            case ButtonType.Exit:
                Application.Quit();
                break;
        }
    }

    private void Setting()
    {
        Debug.Log("Press Setting");
    }

    private void MainMenu()
    {
        Debug.Log("Press Menu");
    }

    private void Pause()
    {
        Debug.Log("Press Menu");
    }

    private void Play()
    {
        Debug.Log("Press Play");
    }
}
