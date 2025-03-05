using UnityEngine;

public class GetActionPlayerInput : MonoBehaviour
{
    private bool _isFly = false;
    private KeyCode _flyKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_flyKey))
            _isFly = true;
    }

    public bool GetIsFly() => GetBoolAsTrigger(ref _isFly);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
