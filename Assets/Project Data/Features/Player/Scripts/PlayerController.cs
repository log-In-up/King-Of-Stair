using System;
using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class PlayerController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AbstractMovement _movement;
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private float _minimumDistance = 0.05f;
        [SerializeField] private float _maximumTime = 1.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float _directionThreshold = 0.9f;
        #endregion

        #region Fields
        private Vector2 _swipeStart;
        private float _swipeStartTime;
        #endregion

        #region Events
        public Action OnMoveForward;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _inputManager.OnStartTouch += SwipeStart;
            _inputManager.OnEndTouch += SwipeEnd;
        }

        private void OnDisable()
        {
            _inputManager.OnStartTouch -= SwipeStart;
            _inputManager.OnEndTouch -= SwipeEnd;
        }
        #endregion

        #region Methods
        private void DetectSwipe(Vector2 position, float time)
        {
            if (Vector3.Distance(_swipeStart, position) >= _minimumDistance &&
                (time - _swipeStartTime) <= _maximumTime)
            {
                Vector3 direction = position - _swipeStart;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
            else
            {
                OnMoveForward?.Invoke();

                _movement.MoveForward();
            }
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
            {
                _movement.MoveLeft();
            }
            else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
            {
                _movement.MoveRight();
            }
        }
        #endregion

        #region Event Handlers
        private void SwipeStart(Vector2 position, float time)
        {
            _swipeStart = position;
            _swipeStartTime = time;
        }

        private void SwipeEnd(Vector2 position, float time) => DetectSwipe(position, time);
        #endregion
    }
}