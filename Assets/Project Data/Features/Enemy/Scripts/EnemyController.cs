using Movement;
using System.Collections;
using UnityEngine;

namespace Enemy
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class EnemyController : MonoBehaviour
    {
        [SerializeField] private AbstractMovement _movement;
        [SerializeField] private JumpMovementData _jumpData;

        private void Update()
        {
            if(_movement.CanMove)
            {
                _movement.MoveForward();
            }
        }
    }
}