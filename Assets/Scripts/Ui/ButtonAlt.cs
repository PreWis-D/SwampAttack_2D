using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAlt : MonoBehaviour
{
    private Button _button;

    private string _funcionName;
    public UnityAction FuncionName => _funcionName;
    public event UnityAction<ButtonAlt> ButtonClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Init(string funcionName)
    {
        _funcionName = funcionName;
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke(this);
    }
}
