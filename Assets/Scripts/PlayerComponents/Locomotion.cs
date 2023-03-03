using Input;
using UnityEngine;

namespace PlayerComponents
{
    public class Locomotion : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float acceleration = 10f;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        private void Update() => _direction = InputReader.Instance.Movement;

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_direction.normalized * (speed * acceleration), ForceMode2D.Force);

            if (_rigidbody.velocity.magnitude > speed)
                _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
        }
    }
}