using UnityEngine;
using System.Collections;

public class EnemyGun : Gun
{
    [SerializeField] private float _durationSpawn;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        StartShooting();
    }

    private void OnDisable()
    {      
        StopShooting();
    }

    public void ReloadGun()
    {
        _bulletSpawner.ClearBulletPool();
    }

    public void StartShooting()
    {
        _coroutine = StartCoroutine(ShootProcess());
    }

    public void StopShooting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    protected override void Shoot()
    {
        _bulletSpawner.GetBullet();
    }

    private IEnumerator ShootProcess()
    {    
        var duration = new WaitForSeconds(_durationSpawn);

        while (true)
        {
            yield return duration;
            Shoot();
        }       
    }
}
