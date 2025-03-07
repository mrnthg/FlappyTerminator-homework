using UnityEngine;
using System.Collections;

public class EnemyGun : Gun
{
    [SerializeField] private float _durationSpawn;

    private void OnEnable()
    {
        StartShooting();
    }

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        BulletSpawner = bulletSpawner;
    }

    public void ReloadGun()
    {
        BulletSpawner.ClearBulletPool();
    }

    private void StartShooting()
    {
        StartCoroutine(ShootProcess());
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
