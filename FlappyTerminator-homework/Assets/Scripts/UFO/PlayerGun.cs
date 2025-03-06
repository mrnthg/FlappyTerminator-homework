using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BulletSpawner))]
public class PlayerGun : Gun
{
    [SerializeField] private ActionPlayerInput _actionPlayerInput;

    private float _startTimeDelayedFire = 0f;
    private float _timeDelayedFire;
    private float _delayedFire = 0.75f;
    private bool _isActiveGun = false;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        BulletSpawner = GetComponent<BulletSpawner>();
        BulletSpawner.SetBulletPosition(transform); 
        
        _isActiveGun = true;
        _timeDelayedFire = _startTimeDelayedFire;
        _actionPlayerInput.Shoots += Shoot;
    }

    private void OnDisable()
    {
        _actionPlayerInput.Shoots -= Shoot;
        _isActiveGun = false;
    }

    public void ReloadGun()
    {
        BulletSpawner.ClearBulletPool();
    }

    protected override void Shoot()
    {
        if (_timeDelayedFire <= 0 && _isActiveGun)
        {
            BulletSpawner.GetBullet();
            _timeDelayedFire = _delayedFire;
            _coroutine = StartCoroutine(CountdownDelay());
        }
    }

    private IEnumerator CountdownDelay()
    {
        while (_timeDelayedFire > 0) 
        {
            _timeDelayedFire -= Time.deltaTime;
            yield return null;
        }

        StopCoroutine(_coroutine);
    }
}
