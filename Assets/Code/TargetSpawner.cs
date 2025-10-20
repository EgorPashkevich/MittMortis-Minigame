using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct PadEntry
    {
        public ActionType type;
        public HitTarget prefab;
        public Vector3 localPos;   
        public Vector3 localEuler; 
    }

    public Transform anchor;        
    public PadEntry[] entries;

    private ObjectPool<HitTarget>[] _pools;

    private void Start()
    {
        _pools = new ObjectPool<HitTarget>[entries.Length];
        for (int i = 0; i < entries.Length; i++)
            _pools[i] = new ObjectPool<HitTarget>(entries[i].prefab, 6, transform);
    }

    public HitTarget Spawn(ActionType t, System.Action<HitTarget> onHit)
    {
        int idx = System.Array.FindIndex(entries, e => e.type == t);
        if (idx < 0) { Debug.LogWarning($"No entry for {t}"); return null; }

        var e = entries[idx];
        var pad = _pools[idx].Get();
        var world = anchor.TransformPoint(e.localPos);
        var rot = anchor.rotation * Quaternion.Euler(e.localEuler);

        pad.transform.SetPositionAndRotation(world, rot);
        pad.Init(e.type, h => { onHit?.Invoke(h); _pools[idx].Release(h); });
        pad.expectedBasis = pad.expectedBasis ? pad.expectedBasis : pad.transform;

        return pad;
    }
}
