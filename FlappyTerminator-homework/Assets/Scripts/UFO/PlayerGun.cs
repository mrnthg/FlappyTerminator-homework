using UnityEngine;

public class PlayerGun : Gun
{
    private float _timeDelayedFire;
    private float _startTimeDelayedFire = 0.75f;
    private PlayerBullet _bullet;

    private void OnEnable()
    {
        _bullet = GetComponent<PlayerBullet>();
    }


    public void ReloadGun()
    {
        _bulletSpawner.ClearBulletPool();
    }

    private void Update()
    {
        Shoot();
    }

    protected override void Shoot()
    {
        if (_timeDelayedFire <= 0)
        {
            if (Input.GetMouseButtonDown(0))
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
