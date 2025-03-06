using UnityEngine;

public class GetActionGunInput : MonoBehaviour
{
    private bool _isShot = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isShot = true;
    }

    public bool GetIsShot() => GetBoolAsTrigger(ref _isShot);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
