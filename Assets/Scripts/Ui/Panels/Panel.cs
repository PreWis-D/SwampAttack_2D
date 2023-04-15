using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Panel : MonoBehaviour
{
    [SerializeField] private float _duration;

    private CanvasGroup _canvasGroup;

    protected void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();  
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _duration);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0, _duration);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
