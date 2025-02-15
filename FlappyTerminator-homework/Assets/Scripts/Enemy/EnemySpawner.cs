using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawners;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
    [SerializeField] protected Game _game;

    private float _durationSpawn = 0.5f; 

    private void Start()
    {
        GetPool();
    }

    public override void ActionOnGet(Enemy enemy)
    {
        _game.Init(enemy);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = _pointsSpawn[RandomPoint()].position;            
        enemy.EnemyRemoved += RemoveObject;
    }

    public override void OnRelease(Enemy enemy)
    {
        StartCoroutine(NewEnemy());
        
        enemy.gameObject.SetActive(false);      
        enemy.EnemyRemoved -= RemoveObject;
    }

    private IEnumerator NewEnemy()
    {
        yield return new WaitForSecondsRealtime(_durationSpawn);
        GetPool();
    }

    private int RandomPoint() =>
        Random.Range(0, _pointsSpawn.Count);
}
