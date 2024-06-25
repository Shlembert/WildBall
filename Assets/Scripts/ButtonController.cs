using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private IUController uiController;
    [SerializeField] private float duration;

    private float _originSize;

    private void Start()
    {
        _originSize = transform.localScale.x;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(_originSize - 0.1f, duration);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_originSize + 0.1f, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_originSize, duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(_originSize, duration).OnComplete(() =>
        {
            uiController.PressButton(buttonType);
        });
    }
}
