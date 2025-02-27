using System;
using UnityEngine;

public class StartScreen : Window
{
    public event Action StartButtonClicked;

    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }

    protected override void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}
