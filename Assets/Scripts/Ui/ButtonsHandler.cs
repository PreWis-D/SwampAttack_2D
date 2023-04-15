using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _nextWeaponButton;
    [SerializeField] private Button _previousWeaponButton;
    [SerializeField] private Button _nextWaveButton;

    public event UnityAction MenuButtonClicked;
    public event UnityAction ShopButtonClicked;
    public event UnityAction NextWeaponButtonClicked;
    public event UnityAction PreviousWeaponButtonClicked;
    public event UnityAction NextWaveButtonClicked;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(MenuButtonOnClicked);
        _shopButton.onClick.AddListener(ShopButtonOnClicked);
        _nextWeaponButton.onClick.AddListener(NextWeaponButtonOnClicked);
        _previousWeaponButton.onClick.AddListener(PreviousWeaponButtonOnClicked);
        _nextWaveButton.onClick.AddListener(NextWaveButtonOnClicked); 
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(MenuButtonOnClicked);
        _shopButton.onClick.RemoveListener(ShopButtonOnClicked);
        _nextWeaponButton.onClick.RemoveListener(NextWeaponButtonOnClicked);
        _previousWeaponButton.onClick.RemoveListener(PreviousWeaponButtonOnClicked);
        _nextWaveButton.onClick.RemoveListener(NextWaveButtonOnClicked);
    }

    public void ShowFadeWaveButton(bool isShowed)
    {
        _nextWaveButton.gameObject.SetActive(isShowed);
    }

    private void MenuButtonOnClicked()
    {
        MenuButtonClicked?.Invoke();
    }

    private void ShopButtonOnClicked()
    {
        ShopButtonClicked?.Invoke();
    }

    private void NextWeaponButtonOnClicked()
    {
        NextWeaponButtonClicked?.Invoke();
    }

    private void PreviousWeaponButtonOnClicked()
    {
        PreviousWeaponButtonClicked?.Invoke();
    }

    private void NextWaveButtonOnClicked()
    {
        NextWaveButtonClicked?.Invoke();
    }
}
