using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : PoolableObject
    {
        [SerializeField] protected T Prefab;
        [SerializeField] protected Transform Parent;

        private ObjectPool<T> _pool;
        private int _defaultSize = 10;
        private int _maxSize = 100;

        public event Action<T> Spawned;

        private void Awake()
        {
            _pool = new ObjectPool<T>(CreateObject, PerformOnGet, OnRelease, Destroy, true, _defaultSize, _maxSize);
        }

        public T CreateObject()
        {
            T newObject = Instantiate(Prefab);
            newObject.transform.SetParent(Parent);
            Spawned?.Invoke(newObject);
            return newObject;
        }

        public abstract void PerformOnGet(T newObject);

        public abstract void OnRelease(T newObject);    

        protected void GetPool()
        {
            _pool.Get();            
        }

        protected void ClearPool()
        {
            _pool.Dispose();
        }

        protected void RemoveObject(T newObject)
        {
            _pool.Release(newObject);
        }
    }
}

