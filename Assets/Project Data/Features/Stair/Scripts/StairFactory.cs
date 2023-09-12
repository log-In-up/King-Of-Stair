using Factory;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Ladder
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class StairFactory : AbstractFactory
    {
        #region Editor Fields
        [SerializeField] private GameObject _stair;
        [SerializeField] private Transform _parent;
        [SerializeField, Min(0)] private int _sizeOfPool = 16;
        [SerializeField] private Vector3 _spawnOrigin;
        [SerializeField] private Vector3 _spawnOffset;
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

            for (int poolIndex = 0; poolIndex < _sizeOfPool; poolIndex++)
            {
                GameObject ladder = Instantiate(_stair, _parent);
                ladder.SetActive(false);

                _ladderQueue.Enqueue(ladder);                
            }
        }

        private void SpawnStairs()
        {
            Vector3 spawnPoint = _spawnOrigin;

            for (int ladderIndex = 0; ladderIndex < _sizeOfPool; ladderIndex++)
            {
                GameObject objectFromPool = CreateEntity();

                objectFromPool.transform.SetPositionAndRotation(spawnPoint, Quaternion.identity);

                spawnPoint += _spawnOffset;
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