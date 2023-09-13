using UnityEngine;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class EnemyCollisionDetector : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;

        private const string ENEMY_TAG = "Enemy";

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag(ENEMY_TAG))
            {
                _controller.OnEnemyDetection();
            }
        }
    }
}