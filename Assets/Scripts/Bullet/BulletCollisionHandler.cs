using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Bullet))]
public class BulletCollisionHandler : MonoBehaviour
{
    private Bullet _bulet;

    public event Action CollisionDetected;

    private void Awake()
    {
        _bulet = GetComponent<Bullet>();
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player) && _bulet.IsEnemyBullet == true
            || collision.TryGetComponent(out Enemy enemy) && _bulet.IsEnemyBullet == false)
        {
            CollisionDetected?.Invoke();
        }
    }
}
