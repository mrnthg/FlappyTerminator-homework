using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

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
        RestartButtonClicked?.Invoke();
    }
}
