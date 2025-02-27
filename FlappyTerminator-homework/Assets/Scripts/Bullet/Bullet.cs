using System.Collections;
using System;
using UnityEngine;

public abstract class Bullet : PoolableObject, IInteractable
{
    [SerializeField] protected float _speed;

    public CollisionHandler _collisionHandler;

    private float _timeDestroy = 3f;   
    private Rigidbody2D _bulletRigidbody;
    private Coroutine _coroutine;

    public event Action<Bullet> BulletRemoved;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _bulletRigidbody = GetComponent<Rigidbody2D>();        
    }

    public abstract void ProcessCollision(IInteractable interactable);

    public virtual void OnEnable()
    {
        _coroutine = StartCoroutine(DestroyBullet());
        Move();
    }

    public virtual void OnDestroy()
    {
        StopCoroutine(_coroutine);
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public virtual void Move()
    {
        _bulletRigidbody.velocity = new Vector2(_speed, _bulletRigidbody.velocity.y);
    }

    public void OnRemove()
    {
        BulletRemoved?.Invoke(this);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_timeDestroy);
        OnRemove();
    }
}
