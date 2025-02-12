using UnityEngine;
using System.Collections;

public class EnemyGun : Gun
{
    [SerializeField] private float _durationSpawn;

    private void OnEnable()
    {
        Debug.Log("ON");
        StartShooting();
    }

    private void OnDisable()
    {
        Debug.Log("OFF");
        StopShooting();
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
