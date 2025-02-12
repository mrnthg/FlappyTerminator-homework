using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    //[SerializeField] private Enemy _enemy;

    private int _score;

    public event Action<int> ScoreChanged;

    //private void OnEnable()
    //{
    //    Debug.Log("podpiska Add");
    //    _enemy.EnemyDied += Add;
    //}

    //private void OnDisable()
    //{
    //    _enemy.EnemyDied -= Add;
    //}

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Add()
    {
        Debug.Log("Plus ochki");
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
