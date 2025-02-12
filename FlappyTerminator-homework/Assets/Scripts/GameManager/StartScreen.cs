using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action StartButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}
