using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Enemy : PoolableObject, IInteractable
{
    [SerializeField] private EnemyGun _gun;

    private CollisionHandler _collisionHandler;

    public event Action<Enemy> Removed;

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
        Removed?.Invoke(this);
        OnGun();
    }

    public void ResetEnemy()
    {
        if (_gun.gameObject.active)
        {
            _gun.ReloadGun();
        }

        OnRemove();
        OnGun();      
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is PlayerBullet || interactable is EnemyRemover)
        {           
            _gun.ReloadGun();
            OffGun();
            OnRemove();           
        }
    }

    private void OffGun()
    {
        _gun.gameObject.SetActive(false);       
    }

    private void OnGun()
    {       
        _gun.gameObject.SetActive(true);
    }
}
