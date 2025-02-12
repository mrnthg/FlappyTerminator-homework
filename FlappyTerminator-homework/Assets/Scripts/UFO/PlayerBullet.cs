using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnEnable()
    {
        StartCoroutine(DestroyBullet());
        Move();

        _collisionHandler.CollisionDetected += ProcessCollision;        
    }

    protected override void OnDestroy()
    {
        StopCoroutine(DestroyBullet());
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            OnRemove();
        }
    }

    protected override void Move()
    {         
        _bulletRigidbody.velocity = new Vector2(_speed, _bulletRigidbody.velocity.y);
    }
}
