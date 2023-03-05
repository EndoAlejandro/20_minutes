using System;
using UnityEngine;
using Weapons;

namespace PlayerComponents
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GunData gunData;
        [SerializeField] private float shootingTime = 0.2f;
        [SerializeField] private float reloadTime = 1f;

        private float _transitionTime;

        public Gun Gun { get; private set; }

        public PlayerState State { get; private set; }

        private void Awake() => State = PlayerState.Idle;

        private void Start() => Gun = new Gun(gunData);

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

        [ContextMenu("UpgradeSpeed")]
        public void UpgradeSpeed() => Gun.SetBulletSpeed(Gun.BulletSpeed * 2);
    }
}