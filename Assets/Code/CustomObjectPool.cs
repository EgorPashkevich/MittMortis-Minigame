using System;
using UnityEngine;
using UnityEngine.Pool;

namespace MittMortis
{
    public class CustomObjectPool<T> where T : Component
    {
        public event Action<T> OnEventRelease;

        private readonly ObjectPool<T> _pool;
        private readonly T _prefab;
        private readonly Transform _parent;

        public CustomObjectPool(T prefab, int prewarm = 0, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            _pool = new ObjectPool<T>(
                CreateFunc,
                OnGet,
                OnRelease,
                OnDestroy,
                collectionCheck: false,
                defaultCapacity: prewarm,
                maxSize: 256
            );
        }

        private T CreateFunc()
        {
            var instance = UnityEngine.Object.Instantiate(_prefab, _parent);
            instance.gameObject.SetActive(false);
            return instance;
        }

        private void OnGet(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        private void OnRelease(T obj)
        {
            obj.gameObject.SetActive(false);
            OnEventRelease?.Invoke(obj);
        }

        private void OnDestroy(T obj)
        {
            if (obj != null)
                UnityEngine.Object.Destroy(obj.gameObject);
        }

        public T Get() => _pool.Get();
    }
}
