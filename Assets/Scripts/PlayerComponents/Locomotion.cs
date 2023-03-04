using Input;
using UnityEngine;

namespace PlayerComponents
{
    public class Locomotion : PlayerComponent
    {
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float reducedSpeed = 3f;
        [SerializeField] private float acceleration = 10f;

        private Vector2 _direction;

        private void Update() => _direction = InputReader.Instance.Movement;

        private void FixedUpdate()
        {
            var movementSpeed = Player.State == PlayerState.Shooting ? reducedSpeed : maxSpeed;
            Rigidbody.AddForce(_direction.normalized * (movementSpeed * acceleration), ForceMode2D.Force);

            if (Rigidbody.velocity.magnitude > movementSpeed)
                Rigidbody.velocity = Rigidbody.velocity.normalized * movementSpeed;
        }
    }
}