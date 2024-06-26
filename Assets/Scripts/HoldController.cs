using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldController : MonoBehaviour
{
    [SerializeField] private GameObject hold;
    [SerializeField] private List<Image> images;
    [SerializeField] private float duration;
    [SerializeField] private float delayBetweenAnimations;

    private void Awake()
    {
        DOTween.SetTweensCapacity(500, 50);
    }

    private async void Start()
    {
        await UniTask.Delay(600);
        HideHold().Forget();
    }

    private async UniTask HideHold()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < images.Count; i++)
        {
            indices.Add(i);
        }

        while (indices.Count > 0)
        {
            int randomIndex = Random.Range(0, indices.Count);
            int imageIndex = indices[randomIndex];
            indices.RemoveAt(randomIndex);

            images[imageIndex].DOFade(0, duration);

            await UniTask.Delay((int)(delayBetweenAnimations));
        }

        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("StartGame");
    }
}
