using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Input
{
    public class InputReader : MonoBehaviour
    {
        public static InputReader Instance { get; private set; }

        public Vector2 Movement => _input != null ? _input.Player.Movement.ReadValue<Vector2>() : Vector2.zero;
        public Vector2 MouseWorld { get; private set; }
        public bool Shoot => _input != null && _input.Player.Shoot.IsPressed();
        public bool Reload => _input != null && _input.Player.Reload.IsPressed();

        private PlayerControls _input;
        
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