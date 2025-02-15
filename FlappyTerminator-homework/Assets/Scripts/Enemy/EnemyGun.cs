using UnityEngine;
using System.Collections;

public class EnemyGun : Gun
{
    [SerializeField] private float _durationSpawn;

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
        StartCoroutine(ShootProcess());
    }

    public void StopShooting()
    {
        StopCoroutine(ShootProcess());
    }

    protected override void Shoot()
    {
        _bulletSpawner.GetBullet();
    }

    private IEnumerator ShootProcess()
    {    
        while (true)
        {           
            yield return new WaitForSecondsRealtime(_durationSpawn);
            Shoot();
        }       
    }
}
