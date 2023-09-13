using Factory;
using System.Collections.Generic;
using UnityEngine;

namespace Ladder
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class StairFactory : AbstractFactory
    {
        #region Editor Fields
        [SerializeField] private Transform _parent;
        [SerializeField] private StairFactoryData _data;
        #endregion

        #region Fields
        private GameObject _ladderToSpawn;
        private Queue<GameObject> _ladderQueue;
        #endregion

        #region MonoBehaviour API
        private void Start()
        {
            InitializeFactory();

            SpawnStairs();
        }
        #endregion

        #region Methods
        private void InitializeFactory()
        {
            _ladderQueue = new Queue<GameObject>();

            for (int poolIndex = 0; poolIndex < _data.SizeOfPool; poolIndex++)
            {
                GameObject ladder = Instantiate(_data.Stair, _parent);
                ladder.SetActive(false);

                _ladderQueue.Enqueue(ladder);                
            }
        }

        private void SpawnStairs()
        {
            Vector3 spawnPoint = _data.SpawnOrigin;

            for (int ladderIndex = 0; ladderIndex < _data.SizeOfPool; ladderIndex++)
            {
                GameObject objectFromPool = CreateEntity();

                objectFromPool.transform.SetPositionAndRotation(spawnPoint, Quaternion.identity);

                spawnPoint += _data.SpawnOffset;
            }
        }
        #endregion

        #region Public API
        public override GameObject CreateEntity()
        {
            _ladderToSpawn = _ladderQueue.Dequeue();
            _ladderToSpawn.SetActive(true);

            _ladderQueue.Enqueue(_ladderToSpawn);

            return _ladderToSpawn;
        }
        #endregion
    }
}