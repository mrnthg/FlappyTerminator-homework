using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawners;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
    [SerializeField] private BulletSpawner _bulletSpawner;

    private float _durationSpawn = 0.5f;
    private WaitForSeconds _duration;

    public event Action<Enemy> EnemySpawned;
    public event Action EnemyRemoved;

    private void Start()
    {
        _duration = new WaitForSeconds(_durationSpawn);
        GetObject();
    }

    public override void PerformOnGet(Enemy enemy)
    {
        EnemySpawned?.Invoke(enemy);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = _pointsSpawn[RandomPoint()].position;
        enemy.Gun.SetBulletSpawner(_bulletSpawner);
        _bulletSpawner.SetBulletPosition(enemy.transform);
        enemy.Removed += RemoveObject;
    }

    public override void OnRelease(Enemy enemy)
    {
        EnemyRemoved?.Invoke();

        enemy.gameObject.SetActive(false);      
        enemy.Removed -= RemoveObject;
        
        StartCoroutine(CreateNewEnemy());
    }

    private IEnumerator CreateNewEnemy()
    {
        yield return _duration;
        GetObject();
    }

    private int RandomPoint() =>
        UnityEngine.Random.Range(0, _pointsSpawn.Count);
}
