using System.Collections;
using UnityEngine;

namespace Movement
{
    public sealed class JumpMovement : AbstractMovement
    {
        #region Editor Fields
        [SerializeField] private JumpMovementData _jumpMovementData;
        #endregion

        #region Fields
        private bool _isJumping;
        private Coroutine _jumpCoroutine;

        private const float ZERO = 0.0f;
        private const int MIDDLE_POINT_DIVIDER = 2;
        private const int TOTAL_TIME = 1;

        public override bool CanMove
        {
            get => _isJumping; 
            protected set
            {
                _isJumping = value;
            }
        }
        #endregion

        #region MonoBehaviour API
        private void OnEnable() => CanMove = true;

        private void OnDisable()
        {
            _jumpCoroutine = null;
            CanMove = true;
        }
        #endregion

        #region Methods
        private IEnumerator Jump(Vector3 startPoint, Vector3 endPoint, Vector3 middlePoint, float jumpDuration)
        {
            CanMove = false;

            float jumpTime = jumpDuration;
            float currentTime;

            Vector3 positionOnArc = new Vector3();
            while (jumpTime >= 0.0f)
            {
                yield return new WaitForEndOfFrame();

                currentTime = 1.0f - (jumpTime / jumpDuration);

                //quadratic Bezier formula
                positionOnArc = (Mathf.Pow(TOTAL_TIME - currentTime, 2) * startPoint) + (2 * currentTime * (TOTAL_TIME - currentTime) * middlePoint) + (Mathf.Pow(currentTime, 2) * endPoint);

                transform.position = positionOnArc;

                jumpTime -= Time.deltaTime;
            }

            transform.position = positionOnArc;

            _jumpCoroutine = null;

            CanMove = true;
        }

        private void LaunchJump(Vector3 destination, float jumpHeight, float jumpDuration)
        {
            Vector3 endPoint = transform.position + destination;

            float x = transform.position.x + (endPoint.x - transform.position.x) / MIDDLE_POINT_DIVIDER;
            float y = (transform.position.y + (endPoint.y - transform.position.y) / MIDDLE_POINT_DIVIDER) + jumpHeight;
            float z = transform.position.z + (endPoint.z - transform.position.z) / MIDDLE_POINT_DIVIDER;

            Vector3 middlePoint = new Vector3(x, y, z);

            _jumpCoroutine = StartCoroutine(Jump(transform.position, endPoint, middlePoint, jumpDuration));
        }
        #endregion

        #region Abstract Realization        
        public override void MoveForward()
        {
            if (_jumpCoroutine != null) return;

            LaunchJump(_jumpMovementData.NextHorizontalJumpPosition, _jumpMovementData.HorizontalJumpHeight, _jumpMovementData.HorizontalJumpDuration);
        }

        public override void MoveLeft()
        {
            if (_jumpCoroutine != null) return;

            LaunchJump(new Vector3(-_jumpMovementData.VerticalJumpDistance, ZERO, ZERO), _jumpMovementData.VerticalJumpHeight, _jumpMovementData.VerticalJumpDuration);
        }

        public override void MoveRight()
        {
            if (_jumpCoroutine != null) return;

            LaunchJump(new Vector3(_jumpMovementData.VerticalJumpDistance, ZERO, ZERO), _jumpMovementData.VerticalJumpHeight, _jumpMovementData.VerticalJumpDuration);
        }
        #endregion
    }
}