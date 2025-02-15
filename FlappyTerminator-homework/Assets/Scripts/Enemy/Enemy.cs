using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Enemy : PoolableObject, IInteractable
{
    [SerializeField] private EnemyGun _enemyGun;

    private CollisionHandler _collisionHandler;   

    public event Action<Enemy> EnemyRemoved;
    public event Action EnemyDied;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        
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
        EnemyDied?.Invoke();
        OnGun();
    }

    public void ResetEnemy()
    {
        OnRemove();
        OnGun();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is PlayerBullet)
        {
                       
            _enemyGun.ReloadGun();
            OffGun();
            OnRemove();           
        }
    }

    private void OffGun()
    {
        _enemyGun.gameObject.SetActive(false);
    }

    private void OnGun()
    {
        _enemyGun.gameObject.SetActive(true);
    }
}
