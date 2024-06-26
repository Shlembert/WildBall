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
    private Transform _transform;

    private void Start()
    {
        _originSize = transform.localScale.x;
        _transform = transform;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _transform.DOScale(_originSize - 0.1f, duration);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _transform.DOScale(_originSize + 0.1f, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _transform.DOScale(_originSize, duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _transform.DOScale(_originSize, duration).OnComplete(() =>
        {
            uiController.PressButton(buttonType);
        });
    }
}
