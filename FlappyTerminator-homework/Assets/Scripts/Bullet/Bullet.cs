using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public abstract class Bullet : PoolableObject, IInteractable
{
    [SerializeField] protected float _speed;

    [NonSerialized] public CollisionHandler collisionHandler;

    private float _timeDestroy = 3f;   
    private Coroutine _coroutine;

    public event Action<Bullet> Removed;

    private void Awake()
    {
        collisionHandler = GetComponent<CollisionHandler>();               
    }

    public abstract void ProcessCollision(IInteractable interactable);

    public virtual void OnEnable()
    {
        collisionHandler.CollisionDetected += ProcessCollision;
        _coroutine = StartCoroutine(DestroyBullet());
    }

    public virtual void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void Update()
    {
        Move();
    }

    public virtual void OnDestroy()
    {
        collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void OnRemove()
    {
        Removed?.Invoke(this);
    }

    private void Move()
    {      
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_timeDestroy);
        OnRemove();
    }
}
