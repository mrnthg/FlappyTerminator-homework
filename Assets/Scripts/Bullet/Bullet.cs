using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(BulletCollisionHandler))]
public abstract class Bullet :PoolableObject, IInteractable 
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isEnemyBullet;

    private BulletCollisionHandler _bulletCollisionHandler;
    private float _timeDestroy = 3f;   
    private Coroutine _coroutine;
    private WaitForSeconds _duration;

    public bool IsEnemyBullet => _isEnemyBullet;

    public event Action<Bullet> Removed;

    private void Awake()
    {     
        _bulletCollisionHandler = GetComponent<BulletCollisionHandler>();
    }

    public virtual void OnEnable()
    {
        _bulletCollisionHandler.CollisionDetected += Remove;
        _duration = new WaitForSeconds(_timeDestroy);

        _coroutine = StartCoroutine(DestroyBullet());
    }

    public virtual void OnDisable()
    {
        _bulletCollisionHandler.CollisionDetected -= Remove;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update()
    {
        Move();
    }

    public void Remove()
    {
        Removed?.Invoke(this);
    }

    private void Move()
    {      
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyBullet()
    {
        yield return _duration;
        Remove();
    }
}
