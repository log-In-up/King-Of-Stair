using Factory;
using Ladder;
using Player;
using System.Collections;
using UnityEngine;

namespace Game
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class GameController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private StairMover _stairMover;
        [SerializeField] private EnemySpawnData _enemySpawnData;
        [SerializeField] private AbstractFactory _factory;
        #endregion

        #region Fields
        private Coroutine _spawnCorotine;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _stairMover.enabled = true;

            _playerController.OnMoveForward += OnPlayerMoveForward;
            _playerController.OnCollisionWithEnemy += OnEnemyAndPlayerCollision;
        }

        private void Start() => _spawnCorotine = StartCoroutine(SpawnEnemies());

        private void OnDisable()
        {
            _playerController.OnMoveForward -= OnPlayerMoveForward;
            _playerController.OnCollisionWithEnemy -= OnEnemyAndPlayerCollision;
        }
        #endregion

        #region Methods
        private IEnumerator SpawnEnemies()
        {
            while (isActiveAndEnabled)
            {
                _factory.CreateEntity();

                yield return new WaitForSeconds(_enemySpawnData.SpawnTime);
            }

            _spawnCorotine = null;
        }
        #endregion

        #region Event Handlers
        private void OnPlayerMoveForward()
        {
            if (_stairMover.enabled)
            {
                _stairMover.CallMoveStair();
            }
        }

        private void OnEnemyAndPlayerCollision() => _stairMover.enabled = false;
        #endregion
    }
}