using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(fileName = "Jump Data", menuName = "Game Data/Movement/Jump Data", order = 0)]
    public sealed class JumpMovementData : ScriptableObject
    {
        [SerializeField, Min(0.0f)] private float _verticalJumpDuration = 0.25f;
        [SerializeField, Min(0.0f)] private float _verticalJumpHeight = 1.25f;
        [SerializeField, Min(0.0f)] private float _verticalJumpDistance = 1.0f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpDuration = 0.1f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpHeight = 1.0f;
        [SerializeField] private Vector3 _nextHorizontalJumpPosition = new Vector3(0.0f, 1.0f, 0.2f);

        public float VerticalJumpDuration => _verticalJumpDuration;
        public float VerticalJumpHeight => _verticalJumpHeight;
        public float VerticalJumpDistance => _verticalJumpDistance;
        public float HorizontalJumpDuration => _horizontalJumpDuration;
        public float HorizontalJumpHeight => _horizontalJumpHeight;
        public Vector3 NextHorizontalJumpPosition => _nextHorizontalJumpPosition;
    }
}