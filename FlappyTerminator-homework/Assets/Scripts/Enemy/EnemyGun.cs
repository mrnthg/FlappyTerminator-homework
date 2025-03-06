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

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        BulletSpawner = bulletSpawner;
    }

    public void ReloadGun()
    {
        BulletSpawner.ClearBulletPool();
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
        BulletSpawner.GetBullet();
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
