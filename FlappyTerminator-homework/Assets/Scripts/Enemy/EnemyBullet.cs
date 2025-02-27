using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void OnEnable()
    {
        base.OnEnable();
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Player)
        {
            OnRemove();
        }
    }

    public override void Move()
    {     
        base.Move();
    }
}
