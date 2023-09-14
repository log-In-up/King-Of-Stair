using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyFactory : AbstractFactory
    {
        #region Editor Fields
        [SerializeField] private EnemySpawnData _enemySpawnData;
        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField] private Transform _spawnParent;
        [SerializeField, Min(0.0f)] private float _objectLifeTime = 17.0f;
        #endregion

        #region Fields
        private Queue<GameObject> _spawnQueue;
        private GameObject _enemy;
        #endregion

        #region Properties
        public override Queue<GameObject> Queue => _spawnQueue;
        #endregion

        #region MonoBehaviour API
        private void Start() => InitializeFactory();
        #endregion

        #region Methods
        private void InitializeFactory()
        {
            _spawnQueue = new Queue<GameObject>();

            int randomIndex;

            for (int poolIndex = 0; poolIndex < _enemySpawnData.SizeOfPool; poolIndex++)
            {
                randomIndex = Random.Range(0, _enemySpawnData.Enemies.Count);

                GameObject enemy = Instantiate(_enemySpawnData.Enemies[randomIndex], _spawnParent);
                enemy.SetActive(false);

                _spawnQueue.Enqueue(enemy);
            }
        }

        private IEnumerator Deactivator(GameObject enemy)
        {
            yield return new WaitForSeconds(_objectLifeTime);

            enemy.SetActive(false);
        }
        #endregion

        #region Overridden Methods
        public override GameObject CreateEntity()
        {
            _enemy = _spawnQueue.Dequeue();
            _enemy.SetActive(true);

            int spawnIndex = Random.Range(0, _spawnPositions.Count);
            Transform spawn = _spawnPositions[spawnIndex];

            _enemy.transform.SetPositionAndRotation(spawn.position, Quaternion.identity);

            StartCoroutine(Deactivator(_enemy));

            _spawnQueue.Enqueue(_enemy);

            return _enemy;
        }
        #endregion
    }
}