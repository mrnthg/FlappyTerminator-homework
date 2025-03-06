using UnityEngine;

public class PlayerBullet : Bullet
{
    public override void OnEnable()
    {
        base.OnEnable();
        ÑollisionHandler.CollisionDetected += ProcessCollision;        
    }

    public override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            Remove();
        }
    }
}
