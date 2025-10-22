using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace MittMortis
{
    public class QuestRefreshRate: MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 120;
        }
    }
}
