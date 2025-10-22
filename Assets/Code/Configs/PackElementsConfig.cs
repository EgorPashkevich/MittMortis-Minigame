using System.Collections.Generic;
using UnityEngine;

namespace MittMortis.Config
{
    [CreateAssetMenu(fileName = "PackElementsConfig", menuName = "Configs/PackElementsConfig", order = 0)]
    public class PackElementsConfig : ScriptableObject
    {
        public List<TrainingElementConfig> trainingElements = new();
    }
}

