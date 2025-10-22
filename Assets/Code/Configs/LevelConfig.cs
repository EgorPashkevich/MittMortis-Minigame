using System.Collections.Generic;
using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public List<PackElementsConfig> packElementsConfig = new();
    }
}
