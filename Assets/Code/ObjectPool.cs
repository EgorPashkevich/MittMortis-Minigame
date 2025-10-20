using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    readonly Stack<T> _stack = new();
    readonly T _prefab; readonly Transform _parent;

    public ObjectPool(T prefab, int prewarm, Transform parent = null)
    {
        _prefab = prefab; _parent = parent;
        for (int i = 0; i < prewarm; i++) _stack.Push(Create());
    }

    T Create() => Object.Instantiate(_prefab, _parent);

    public T Get()
    {
        var obj = _stack.Count > 0 ? _stack.Pop() : Create();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        _stack.Push(obj);
    }
}
