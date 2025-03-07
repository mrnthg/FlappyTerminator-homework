using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    public event Action ButtonClicked;

    public CanvasGroup WindowGroup => _windowGroup;
    public Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public virtual void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }

    public virtual void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public virtual void Close()
    {
        WindowGroup.alpha = 0;
        ActionButton.interactable = false;
    }
}
