using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawners;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();

    private float _durationSpawn = 0.5f;

    public event Action<Enemy> EnemySpawned;
    public event Action EnemyRemoved;

    private void Start()
    {
        GetPool();
    }

    public override void PerformOnGet(Enemy enemy)
    {
        EnemySpawned?.Invoke(enemy);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = _pointsSpawn[RandomPoint()].position;            
        enemy.Removed += RemoveObject;
    }

    public override void OnRelease(Enemy enemy)
    {
        EnemyRemoved?.Invoke();

        enemy.gameObject.SetActive(false);      
        enemy.Removed -= RemoveObject;
        
        StartCoroutine(NewEnemy());
    }

    private IEnumerator NewEnemy()
    {
        yield return new WaitForSeconds(_durationSpawn);
        GetPool();
    }

    private int RandomPoint() =>
        UnityEngine.Random.Range(0, _pointsSpawn.Count);
}
