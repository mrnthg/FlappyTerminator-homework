using UnityEngine;
using Spawners;

public class BulletSpawner : Spawner<Bullet>
{
    private Transform _transform;

    private void OnEnable()
    {
        _transform = GetComponent<Transform>();
    }

    public override void ActionOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);

        bullet.transform.position = _transform.position;
        bullet.BulletRemoved += RemoveObject;
    }

    public override void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.BulletRemoved -= RemoveObject;
    }

    public void GetBullet()
    {
        GetPool();
    }

    public void ClearBulletPool()
    {
        foreach (Transform child in _parent)
        {
            if (child.TryGetComponent(out Bullet bullet))
            {
                bullet.OnRemove();
            }           
        }
    }
}
