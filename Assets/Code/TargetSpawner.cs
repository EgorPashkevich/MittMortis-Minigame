using MittMortis.Config;
using System;
using UnityEngine;

namespace MittMortis
{
    [Serializable]
    public class TargetSpawner
    {
        [SerializeField] private PoolInit poolInit;
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private Transform ContentRoot;
        [SerializeField] private Transform poolElement;

        public event Action OnEndPackElements;

        private GameSession gameSession;

        private int indexPackElement;
        private int indexElement;
        private bool isSession;

        public void Init(GameSession session)
        {
            gameSession = session;
            poolElement.transform.position = Vector3.zero;
            poolInit.Init(poolElement);
            poolInit.OnObjectRelease += gameSession.ReleaseObject;
        }

        public TrainingElement Spawn()
        {
            if (!isSession) 
            {
                indexPackElement = UnityEngine.Random.Range(0, levelConfig.packElementsConfig.Count);
                isSession = true;
                OnEndPackElements?.Invoke();
            }
            var trainingConfig = levelConfig.packElementsConfig[indexPackElement].trainingElements[indexElement];
            indexElement++;

            if(indexElement >= levelConfig.packElementsConfig[indexPackElement].trainingElements.Count)
            {
                isSession = false; 
                indexElement = 0;
            }

            var element = trainingConfig.Create(new() { poolInit = poolInit });
            gameSession.AddObject(element);
            element.transform.position += ContentRoot.position;
            return element;
        }
    }
}
