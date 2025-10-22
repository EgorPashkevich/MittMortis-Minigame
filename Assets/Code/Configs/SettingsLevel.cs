using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "SettingsLevel", menuName = "Configs/SettingsLevel", order = 0)]
    public class SettingsLevel : ScriptableObject
    {
        [field: SerializeField] public int CountLives {  get; private set; }
        [field: SerializeField] public float StartSpawnInterval { get; private set; } = 2f;
        [field: SerializeField] public float MultiplerSpawnInterval { get; private set; } = 0.9f;
        [field: SerializeField] public float startDelay { get; private set; } = 0.8f;
        [field: SerializeField] public List<SettingsSpeed> SettingsSpeed { get; private set; }
        [field: SerializeField] public List<SettingsStrick> SettingsStrick {  get; private set; }
    }
    [Serializable]
    public class SettingsStrick
    {
        [field: SerializeField] public int CountStrick { get; private set; }
        [field: SerializeField] public int MultiplerScore { get; private set; }
    }
    [Serializable]
    public class SettingsSpeed
    {
        [field: SerializeField] public int CountPacksElements {  get; private set; }
        [field: SerializeField] public int SpawnInterval { get; private set; }
    }
}
