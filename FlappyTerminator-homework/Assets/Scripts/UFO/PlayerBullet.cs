using UnityEngine;

public class PlayerBullet : Bullet
{
    public override void OnEnable()
    {
        base.OnEnable();
        collisionHandler.CollisionDetected += ProcessCollision;        
    }

    public override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            OnRemove();
        }
    }
}
