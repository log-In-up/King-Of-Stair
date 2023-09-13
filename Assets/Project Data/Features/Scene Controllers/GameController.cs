using Ladder;
using Player;
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
        #endregion

        #region MonoBehaviour API
        private void OnEnable() => _playerController.OnMoveForward += OnPlayerMoveForward;

        private void OnDisable() => _playerController.OnMoveForward -= OnPlayerMoveForward;
        #endregion

        #region Methods
        private void OnPlayerMoveForward() => _stairMover.CallMoveStair();
        #endregion
    }
}