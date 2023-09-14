using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(fileName = "Jump Data", menuName = "Game Data/Movement/Jump Data", order = 0)]
    public sealed class JumpMovementData : ScriptableObject
    {
        [SerializeField, Min(0.0f)] private float _horizontalJumpDuration = 0.25f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpHeight = 1.25f;
        [SerializeField, Min(0.0f)] private float _horizontalJumpDistance = 1.0f;
        [SerializeField, Min(0.0f)] private float _verticalJumpDuration = 0.25f;
        [SerializeField, Min(0.0f)] private float _verticalJumpHeight = 3.0f;
        [SerializeField] private Vector3 _nextVerticalJumpPosition = new Vector3(0.0f, 0.0f, 0.0f);

        public float HorizontalJumpDuration => _horizontalJumpDuration;
        public float HorizontalJumpHeight => _horizontalJumpHeight;
        public float HorizontalJumpDistance => _horizontalJumpDistance;
        public float VerticalJumpDuration => _verticalJumpDuration;
        public float VerticalJumpHeight => _verticalJumpHeight;
        public Vector3 NextVerticalJumpPosition => _nextVerticalJumpPosition;
    }
}