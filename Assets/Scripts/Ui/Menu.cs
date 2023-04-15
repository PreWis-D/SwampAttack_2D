using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    [SerializeField] private EventAggregator _eventAggregator;
    [SerializeField] private ButtonsHandler _buttonsHandler;

    [Header("Panels")]
    [SerializeField] private MenuPanel _menuPanel;
    [SerializeField] private ShopPanel _shopPanel;

    [Header("Viewes")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ProgressBar _progressBar;

    public event UnityAction NextWaveButtonClicked;
    public event UnityAction PanelShowed;
    public event UnityAction PanelHided;

    private void Awake()
    {
        _shopPanel.Init(_eventAggregator.Player);
        _healthBar.Init(_eventAggregator.Player);
        _progressBar.Init(_eventAggregator.Spawner);
    }

    private void OnEnable()
    {
        _eventAggregator.AllEnemySpawned += OnAllEnemySpawned;

        #region ButtonsHandlerActions
        _buttonsHandler.MenuButtonClicked += OnMenuButtonClicked;
        _buttonsHandler.ShopButtonClicked += OnShopButtonClicked;
        _buttonsHandler.NextWeaponButtonClicked += OnNextWeaponButtonClicked;
        _buttonsHandler.PreviousWeaponButtonClicked += OnPreviosWeaponButtonClicked;
        _buttonsHandler.NextWaveButtonClicked += OnNextWaveButtonClicked;
        #endregion

        #region MenuPanelActions
        _menuPanel.ContinueButtonClicked += OnContinueButtonClicked;
        _menuPanel.ExitButtonClicked += OnExitMenuButtonClicked;
        #endregion

        _shopPanel.ExitButtonClicked += OnExitShopButtonClicked;
    }

    private void OnDisable()
    {
        _eventAggregator.AllEnemySpawned -= OnAllEnemySpawned;

        #region ButtonsHandlerActions
        _buttonsHandler.MenuButtonClicked -= OnMenuButtonClicked;
        _buttonsHandler.ShopButtonClicked -= OnShopButtonClicked;
        _buttonsHandler.NextWeaponButtonClicked -= OnNextWeaponButtonClicked;
        _buttonsHandler.PreviousWeaponButtonClicked -= OnPreviosWeaponButtonClicked;
        _buttonsHandler.NextWaveButtonClicked -= OnNextWaveButtonClicked;
        #endregion

        #region MenuPanelActions
        _menuPanel.ContinueButtonClicked -= OnContinueButtonClicked;
        _menuPanel.ExitButtonClicked -= OnExitMenuButtonClicked;
        #endregion

        _shopPanel.ExitButtonClicked -= OnExitShopButtonClicked;
    }

    #region ButtonsHandlerActions
    private void OnMenuButtonClicked()
    {
        ShowPanel(_menuPanel);
    }

    private void OnShopButtonClicked()
    {
        ShowPanel(_shopPanel);
    }

    private void OnNextWeaponButtonClicked()
    {
        
    }

    private void OnPreviosWeaponButtonClicked()
    {

    }

    private void OnNextWaveButtonClicked()
    {
        NextWaveButtonClicked?.Invoke();
        _buttonsHandler.ShowFadeWaveButton(false);
    }
    #endregion

    #region MenuPanelActions
    private void OnContinueButtonClicked()
    {
        HidePanel(_menuPanel);
    }

    private void OnExitMenuButtonClicked()
    {
        Application.Quit();
    }
    #endregion

    private void OnAllEnemySpawned()
    {
        _buttonsHandler.ShowFadeWaveButton(true);
    }

    private void OnExitShopButtonClicked()
    {
        HidePanel(_shopPanel);
    }

    private void ShowPanel(Panel panel)
    {
        PanelShowed?.Invoke();
        panel.Show();
    }

    private void HidePanel(Panel panel)
    {
        PanelHided?.Invoke();
        panel.Hide();
    }

}