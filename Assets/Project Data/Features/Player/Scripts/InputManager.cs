using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Utilities;

namespace Player
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class InputManager : MonoBehaviour
    {
        #region Fields
        private InputActions _input;
        #endregion

        #region Events
        public Action<Vector2, float> OnStartTouch, OnEndTouch;
        #endregion

        #region MonoBehaviour API
        private void Awake() => _input = new InputActions();

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.PrimaryContact.started += OnStartTouchPrimary;
            _input.Player.PrimaryContact.canceled += OnEndTouchPrimary;
        }

        private void OnDisable()
        {
            _input.Player.PrimaryContact.started -= OnStartTouchPrimary;
            _input.Player.PrimaryContact.canceled -= OnEndTouchPrimary;

            _input.Disable();
        }
        #endregion

        #region Event Handlers
        private void OnStartTouchPrimary(InputAction.CallbackContext callbackContext)
        {
            if (OnStartTouch == null) return;

            Vector2 touchPosition = _input.Player.PrimaryPosition.ReadValue<Vector2>();
            OnStartTouch.Invoke(Utils.ScreenToWorld(Camera.main, touchPosition), (float)callbackContext.startTime);
        }

        private void OnEndTouchPrimary(InputAction.CallbackContext callbackContext)
        {
            if (OnEndTouch == null) return;

            Vector2 touchPosition = _input.Player.PrimaryPosition.ReadValue<Vector2>();
            OnEndTouch.Invoke(Utils.ScreenToWorld(Camera.main, touchPosition), (float)callbackContext.time);
        }
        #endregion
    }
}