using System;
using UnityEngine;

public class Enemy : PoolableObject, IInteractable
{
    [SerializeField] private EnemyGun _enemyGun;

    //[SerializeField] private ScoreCounter _scoreCounter;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;   

    public event Action<Enemy> EnemyRemoved;
    public event Action EnemyDied;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<CollisionHandler>();
        Debug.Log("Reset active1? : " + gameObject.activeInHierarchy);
        OffGun();
    }

    private void OnEnable()
    {       
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void OnRemove()
    {
        EnemyRemoved?.Invoke(this);
    }

    public void ResetEnemy()
    {
        Debug.Log("Reset active? : " + gameObject.activeInHierarchy);

        OnRemove();
        OnGun();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is PlayerBullet)
        {
            OffGun();
            OnRemove();           
        }
    }

    private void OffGun()
    {
        //_enemyGun.StopShooting();
        _enemyGun.gameObject.SetActive(false);
    }

    private void OnGun()
    {
        

        _enemyGun.gameObject.SetActive(true);
        //_enemyGun.StartShooting();
    }
}
