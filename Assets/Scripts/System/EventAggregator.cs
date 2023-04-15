using UnityEngine;
using UnityEngine.Events;

public class EventAggregator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Menu _menu;

    public Spawner Spawner => _spawner;
    public Player Player => _player;

    public event UnityAction AllEnemySpawned;
    public event UnityAction NextWaveButtonClicked;
    public event UnityAction PanelShowed;
    public event UnityAction PanelHided;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _menu.NextWaveButtonClicked += OnNextWaveButtonClicked;
        _menu.PanelShowed += OnPanelShowed;
        _menu.PanelHided += OnPanelHided;
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _menu.NextWaveButtonClicked -= OnNextWaveButtonClicked;
        _menu.PanelShowed -= OnPanelShowed;
        _menu.PanelHided -= OnPanelHided;
    }

    private void OnAllEnemySpawned()
    {
        PassEvent(AllEnemySpawned);
    }

    private void OnNextWaveButtonClicked()
    {
        PassEvent(NextWaveButtonClicked);
    }

    private void OnPanelShowed()
    {
        PassEvent(PanelShowed);
    }

    private void OnPanelHided()
    {
        PassEvent(PanelHided);
    }

    private void PassEvent(UnityAction action)
    {
        action?.Invoke();
    }
}
