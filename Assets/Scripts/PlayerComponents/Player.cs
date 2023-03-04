using System;
using UnityEngine;

namespace PlayerComponents
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float shootingTime = 0.2f;
        [SerializeField] private float reloadTime = 1f;

        private float _transitionTime;

        public PlayerState State { get; private set; }

        private void Awake() => State = PlayerState.Idle;

        private void Update()
        {
            if (State == PlayerState.Idle) return;
            _transitionTime -= Time.deltaTime;

            if (_transitionTime <= 0) NextState();
        }

        private void NextState()
        {
            switch (State)
            {
                case PlayerState.Shooting:
                    State = PlayerState.Idle;
                    break;
                case PlayerState.Reloading:
                    State = PlayerState.Idle;
                    //TODO: reload weapon
                    break;
            }
        }

        public void SetState(PlayerState state)
        {
            State = state;
            switch (State)
            {
                case PlayerState.Shooting:
                    _transitionTime = shootingTime;
                    break;
                case PlayerState.Reloading:
                    _transitionTime = reloadTime;
                    break;
            }
        }
    }
}