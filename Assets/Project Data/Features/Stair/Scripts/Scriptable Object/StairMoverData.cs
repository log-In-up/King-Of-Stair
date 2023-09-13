using UnityEngine;

namespace Ladder
{
    [CreateAssetMenu(fileName = "Stair Mover Data", menuName = "Game Data/Game/Stair Mover Data", order = 0)]
    public sealed class StairMoverData : ScriptableObject
    {
        [SerializeField, Min(0.1f)] private float _moveSpeed = 4.0f;
        [SerializeField, Min(0.1f)] private float _moveDistance = 1.0f;
        [SerializeField] private Vector3 _topPosition = new Vector3(0.0f, 11.0f, 11.5f);
        [SerializeField] private Vector3 _moveDirection = new Vector3(0.0f, -1.0f, -1.0f);

        public float MoveSpeed => _moveSpeed;
        public float MoveDistance => _moveDistance;
        public Vector3 TopPosition => _topPosition;
        public Vector3 MoveDirection => _moveDirection;
    }
}