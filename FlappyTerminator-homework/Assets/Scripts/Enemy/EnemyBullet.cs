using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void OnEnable()
    {
        base.OnEnable();
        collisionHandler.CollisionDetected += ProcessCollision;
    }

    public override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Player)
        {
            OnRemove();
        }
    }
}
