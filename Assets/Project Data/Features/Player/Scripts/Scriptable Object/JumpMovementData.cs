using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Jump Data", menuName = "Game Data/Player/Jump Data", order = 0)]
    public sealed class JumpMovementData : ScriptableObject
    {
        [SerializeField, Min(0.0f)] private float _horizontalJumpDuration = 0.1f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpHeight = 1.0f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpDistance = 1.0f;
        [SerializeField, Min(0.0f)] private float _verticalJumpDuration = 0.25f;
        [SerializeField, Min(0.0f)] private float _verticalJumpHeight = 1.25f;
        [SerializeField] private Vector3 _nextVerticalJumpPosition = new Vector3(0.0f, 1.0f, 0.2f);

        public float HorizontalJumpDuration => _horizontalJumpDuration;
        public float VerticalJumpDuration => _verticalJumpDuration;
        public float HorizontalJumpHeight => _horizontalJumpHeight;
        public float VerticalJumpHeight => _verticalJumpHeight;
        public float HorizontalJumpDistance => _horizontalJumpDistance;
        public Vector3 NextVerticalJumpPosition => _nextVerticalJumpPosition;
    }
}