using System.Collections;
using System;
using UnityEngine;

public abstract class Bullet : PoolableObject, IInteractable
{
    [SerializeField] protected float _speed;
    
    protected float _timeDestroy = 3f;
    protected CollisionHandler _collisionHandler;
    protected Rigidbody2D _bulletRigidbody;

    public event Action<Bullet> BulletRemoved;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _bulletRigidbody = GetComponent<Rigidbody2D>();        
    }

    protected abstract void OnEnable();

    protected abstract void OnDestroy();

    protected abstract void ProcessCollision(IInteractable interactable);

    protected abstract void Move();

    public void OnRemove()
    {
        BulletRemoved?.Invoke(this);
    }

    protected IEnumerator DestroyBullet()
    {
        yield return new WaitForSecondsRealtime(_timeDestroy);
        OnRemove();
    }
}
