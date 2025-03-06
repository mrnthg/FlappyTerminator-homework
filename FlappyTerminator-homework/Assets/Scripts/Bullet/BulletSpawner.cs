using UnityEngine;
using Spawners;
using UnityEngine.Pool;

public class BulletSpawner : Spawner<Bullet>
{
    private Transform _transform;

    public override void PerformOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _transform.position;
        bullet.transform.rotation = _transform.rotation;
        bullet.Removed += RemoveObject;
    }

    public void SetBulletPosition(Transform transform)
    {
        _transform = transform;
    }

    public override void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.Removed -= RemoveObject;
    }

    public void GetBullet()
    {
        GetPool();
    }

    public void ClearBulletPool()
    {
        foreach (Transform child in Parent)
        {
            if (child.TryGetComponent(out Bullet bullet))
            {
                bullet.Remove();
            }           
        }
    }
}
