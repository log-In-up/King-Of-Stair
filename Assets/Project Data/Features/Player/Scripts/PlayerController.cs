using System;
using UnityEngine;
using Movement;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AbstractMovement _movement;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private GameObject _mesh;
        [SerializeField] private float _minimumDistance = 0.05f;
        [SerializeField] private float _maximumTime = 1.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float _directionThreshold = 0.9f;
        #endregion

        #region Fields
        private Rigidbody _rigidbody;
        private Vector2 _swipeStart;
        private float _swipeStartTime;
        #endregion

        #region Events
        public Action OnMoveForward;
        public Action OnCollisionWithEnemy;
        #endregion

        #region MonoBehaviour API
        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            _movement.enabled = true;
            _mesh.SetActive(true);

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
            if (!_movement.enabled) return;

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

        #region Public API
        protected internal void OnEnemyDetection()
        {
            _movement.enabled = false;

            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            _mesh.SetActive(false);

            OnCollisionWithEnemy?.Invoke();
        }
        #endregion
    }
}