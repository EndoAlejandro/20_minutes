using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Input
{
    public class InputReader : MonoBehaviour
    {
        public static InputReader Instance { get; private set; }

        private PlayerControls _input;

        public Vector2 Movement => _input != null ? _input.Player.Movement.ReadValue<Vector2>() : Vector2.zero;
        public Vector2 MouseWorld { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _input = new PlayerControls();
            _input.Enable();
        }

        private void Update() => MouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }
}