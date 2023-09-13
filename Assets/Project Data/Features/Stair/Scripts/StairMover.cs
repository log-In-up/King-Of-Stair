using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ladder
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class StairMover : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AbstractFactory _factory;
        [SerializeField] private Transform _parentForLadder;
        [SerializeField] private StairMoverData _data;
        #endregion

        #region Fields
        private Coroutine _move;
        private float _moveTime;
        #endregion

        #region MonoBehaviour API
        private void Start() => _moveTime = _data.MoveDistance / _data.MoveSpeed;
        #endregion

        #region Methods        
        private IEnumerator Move()
        {
            List<GameObject> ladders = new List<GameObject>();

            foreach (Transform transform in _parentForLadder)
            {
                ladders.Add(transform.gameObject);
            }

            GameObject stair = _factory.CreateEntity();
            stair.transform.SetPositionAndRotation(_data.TopPosition, Quaternion.identity);

            float moveDuration = _moveTime;

            while (moveDuration >= 0.0f)
            {
                yield return new WaitForEndOfFrame();

                foreach (GameObject ladder in ladders)
                {
                    if (transform.gameObject.activeSelf)
                    {
                        ladder.transform.Translate(_data.MoveSpeed * Time.deltaTime * _data.MoveDirection);
                    }
                }

                moveDuration -= Time.deltaTime;
            }

            _move = null;
        }
        #endregion

        #region Public API
        public void CallMoveStair()
        {
            if (_move != null) return;

            _move = StartCoroutine(Move());
        }
        #endregion
    }
}