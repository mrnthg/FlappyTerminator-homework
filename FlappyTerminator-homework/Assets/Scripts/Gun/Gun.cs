using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
public abstract class Gun : MonoBehaviour
{
    protected BulletSpawner _bulletSpawner;

    protected void Awake()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    protected abstract void Shoot();
}
