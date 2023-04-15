using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuPanel : Panel
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction ContinueButtonClicked;
    public event UnityAction ExitButtonClicked;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnContinueButtonClick()
    {
        ContinueButtonClicked?.Invoke();
    }

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }
}
