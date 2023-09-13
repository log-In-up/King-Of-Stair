using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Enemy Spawn Data", menuName = "Game Data/Game/Enemy Spawn Data", order = 0)]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] private List<GameObject> _enemies;
        [SerializeField, Min(0.0f)] private float _spawnTime;
        [SerializeField, Min(0)] private int _sizeOfPool = 5;

        public List<GameObject> Enemies => _enemies;
        public float SpawnTime => _spawnTime;
        public int SizeOfPool => _sizeOfPool;
    }
}