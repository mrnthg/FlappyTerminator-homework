using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public abstract class Bullet : PoolableObject, IInteractable
{
    [SerializeField] protected float Speed;

    [NonSerialized] public CollisionHandler ÑollisionHandler;

    private float _timeDestroy = 3f;   
    private Coroutine _coroutine;

    public event Action<Bullet> Removed;

    private void Awake()
    {
        ÑollisionHandler = GetComponent<CollisionHandler>();               
    }

    public abstract void ProcessCollision(IInteractable interactable);

    public virtual void OnEnable()
    {
        ÑollisionHandler.CollisionDetected += ProcessCollision;
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
        ÑollisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Remove()
    {
        Removed?.Invoke(this);
    }

    private void Move()
    {      
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_timeDestroy);
        Remove();
    }
}
