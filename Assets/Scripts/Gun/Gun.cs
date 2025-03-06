using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    protected BulletSpawner BulletSpawner;

    protected abstract void Shoot();
}
