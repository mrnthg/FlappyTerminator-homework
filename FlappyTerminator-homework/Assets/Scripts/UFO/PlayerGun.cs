using UnityEngine;

public class PlayerGun : Gun
{
    private GetActionGunInput _getActionGunInput;
    private float _timeDelayedFire;
    private float _startTimeDelayedFire = 0.75f;

    private void OnEnable()
    {
        _getActionGunInput = GetComponent<GetActionGunInput>();
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
            if (_getActionGunInput.GetIsShot())
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
