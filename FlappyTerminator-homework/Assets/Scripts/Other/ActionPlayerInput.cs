using System;
using UnityEngine;

public class ActionPlayerInput : MonoBehaviour
{
    private bool _isFly = false;
    private KeyCode _flyKey = KeyCode.Space;

    public event Action Shoots;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoots?.Invoke();        

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
