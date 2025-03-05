using UnityEngine;
using Spawners;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Transform _transform;

    private void OnEnable()
    {
        //_transform = GetComponent<Transform>();
    }

    public override void PerformOnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _transform.position;
        bullet.transform.rotation = _transform.rotation;
        bullet.Removed += RemoveObject;
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
        foreach (Transform child in _parent)
        {
            if (child.TryGetComponent(out Bullet bullet))
            {
                bullet.OnRemove();
            }           
        }
    }
}
