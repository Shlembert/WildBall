using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class IUController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private List<Transform> buttonsMenu;
    [SerializeField] private List<Transform> buttonsLevel;
    [SerializeField] private GameObject levelPanel, settingPanel;
    [SerializeField] private float duration;
    [SerializeField] private float direction;
    [SerializeField] private float delayBetweenAnimations;
    [SerializeField] private float speedStart;

    public void PressButton(ButtonType buttonType)
    {
        DOTween.KillAll();

        switch (buttonType)
        {
            case ButtonType.Play:
                Play().Forget();
                break;
            case ButtonType.Pause:
                Pause();
                break;
            case ButtonType.MainMenu:
                MainMenu();
                break;
            case ButtonType.Setting:
                Setting().Forget();
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

    private async UniTask Setting()
    {
        await MoveButtonMenu(direction, Ease.InBack);
        ShowSetting();
    }

    private void MainMenu()
    {

        sceneController.SceneLoad(0);
    }

    private void Pause()
    {
        Debug.Log("Press Menu");
    }

    private async UniTask Play()
    {
        await HideButtonsMenu();
    }

    private void ShowButtonsMenu()
    {
        MoveButtonMenu(0, Ease.OutBack);
    }

    private async UniTask HideButtonsMenu()
    {
        await MoveButtonMenu(direction, Ease.InBack);
        await ShowButtonsLevel();
    }

    private async UniTask ShowButtonsLevel()
    {
        levelPanel.SetActive(true);
        await MoveButtonLevel(direction, Ease.OutBack);
    }

    private void ShowSetting()
    {
        settingPanel.SetActive(true);
        settingPanel.transform.DOScale(0, 0.3f).From().SetEase(Ease.OutBack);
    }

    private UniTask MoveButtonMenu(float dir, Ease ease)
    {
        var tcs = new UniTaskCompletionSource();

        int completedAnimations = 0;

        for (int i = 0; i < buttonsMenu.Count; i++)
        {
            var button = buttonsMenu[i];
            float delay = i * delayBetweenAnimations;
            button.DOMoveX(dir, duration)
                .SetEase(ease, 0.5f)
                .SetDelay(delay * speedStart)
                .OnComplete(() =>
                {
                    completedAnimations++;
                    if (completedAnimations >= buttonsMenu.Count)
                    {
                        tcs.TrySetResult();
                    }
                });
        }

        return tcs.Task;
    }

    private UniTask MoveButtonLevel(float dir, Ease ease)
    {
        var tcs = new UniTaskCompletionSource();

        int completedAnimations = 0;

        for (int i = 0; i < buttonsLevel.Count; i++)
        {
            var button = buttonsLevel[i];
            float delay = (buttonsMenu.Count - 1 - i) * delayBetweenAnimations;
            button.DOMoveX(dir, duration)
                .From()
                .SetEase(ease, 0.5f)
                .SetDelay(delay * speedStart)
                .OnComplete(() =>
                {
                    completedAnimations++;
                    if (completedAnimations >= buttonsLevel.Count)
                    {
                        tcs.TrySetResult();
                    }
                });
        }

        return tcs.Task;
    }
}
