using Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ladder
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class StairMover : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AbstractFactory _factory;
        [SerializeField] private Transform _parentForLadder;
        [SerializeField, Min(0.1f)] private float _moveSpeed = 1.0f;
        [SerializeField, Min(0.1f)] private float _moveDistance = 1.0f;        
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private Vector3 _topPosition;
        #endregion

        #region Fields
        private Coroutine _move;
        private float _moveTime;
        #endregion

        #region MonoBehaviour API
        private void Start() => _moveTime = _moveDistance / _moveSpeed;

        private void Update()
        {
            //Temporary logic to call the ladder to move
            if (Input.GetKey(KeyCode.Space) && _move == null)
            {
                _move = StartCoroutine(Move());
            }
        }
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
            stair.transform.SetPositionAndRotation(_topPosition, Quaternion.identity);

            float moveDuration = _moveTime;

            while (moveDuration >= 0.0f)
            {
                yield return new WaitForEndOfFrame();

                foreach (GameObject ladder in ladders)
                {
                    if (transform.gameObject.activeSelf)
                    {
                        ladder.transform.Translate(_moveSpeed * Time.deltaTime * _moveDirection);
                    }
                }

                moveDuration -= Time.deltaTime;
            }

            _move = null;
        }
        #endregion
    }
}