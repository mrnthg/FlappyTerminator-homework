using UnityEngine;

public class PlayerGun : Gun
{
    private GetActionInput _getActionInput;
    private float _timeDelayedFire;
    private float _startTimeDelayedFire = 0.75f;

    private void OnEnable()
    {
        _getActionInput = GetComponent<GetActionInput>();
    }

    private void Update()
    {
        Shoot();
    }

    public void ReloadGun()
    {
        _bulletSpawner.ClearBulletPool();
    }

    protected override void Shoot()
    {
        if (_timeDelayedFire <= 0)
        {
            if (_getActionInput.GetIsShot())
            {
                _bulletSpawner.GetBullet();
                _timeDelayedFire = _startTimeDelayedFire;
            }
        }
        else
        {
            _timeDelayedFire -= Time.deltaTime;
        }
    }
}
