using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private Enemy _enemy;
    private int _score;

    public event Action<int> ScoreChanged;

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Add()
    {       
        _score++;
        ScoreChanged?.Invoke(_score); 
        _enemy.EnemyDied -= Add;
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.EnemyDied += Add;
    }
}
