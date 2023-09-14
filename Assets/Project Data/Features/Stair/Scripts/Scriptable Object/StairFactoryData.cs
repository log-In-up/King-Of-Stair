using UnityEngine;

namespace Ladder
{
    [CreateAssetMenu(fileName = "Stair Factory Data", menuName = "Game Data/Game/Stair Factory Data", order = 0)]
    public sealed class StairFactoryData : ScriptableObject
    {
        [SerializeField, Min(0)] private int _sizeOfPool = 16;
        [SerializeField] private GameObject _stair;
        [SerializeField] private Vector3 _spawnOrigin = new Vector3(0.0f, -5.0f, -4.5f);
        [SerializeField] private Vector3 _spawnOffset = new Vector3(0.0f, 1.0f, 1.0f);

        public int SizeOfPool => _sizeOfPool;
        public GameObject Stair => _stair;
        public Vector3 SpawnOrigin => _spawnOrigin;
        public Vector3 SpawnOffset => _spawnOffset;
    }
}