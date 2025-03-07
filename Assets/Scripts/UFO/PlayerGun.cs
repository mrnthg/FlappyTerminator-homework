using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BulletSpawner))]
public class PlayerGun : Gun
{
    [SerializeField] private ActionPlayerInput _actionPlayerInput;

    private float _delayedFire = 0.75f;
    private bool _canShoot = false;
    private WaitForSeconds _duration;

    private void OnEnable()
    {
        BulletSpawner = GetComponent<BulletSpawner>();
        BulletSpawner.SetBulletPosition(transform);

        _duration = new WaitForSeconds(_delayedFire);
        _canShoot = true;
        _actionPlayerInput.Shoots += Shoot;
    }

    private void OnDisable()
    {
        _actionPlayerInput.Shoots -= Shoot;
        _canShoot = false;
    }

    public void ReloadGun()
    {
        BulletSpawner.ClearBulletPool();
    }

    protected override void Shoot()
    {
        if (_canShoot)
        {
            BulletSpawner.GetBullet();
            StartCoroutine(CountdownDelay());
        }
    }

    private IEnumerator CountdownDelay()
    {
        _canShoot = false;

        yield return _duration;

        _canShoot = true;
    }
}
