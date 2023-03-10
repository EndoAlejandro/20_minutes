using UnityEngine;

namespace EnemyComponents
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private float speed = 1f;
        [SerializeField] private ExperiencePoint xpPrefab;

        private int _health;

        private Vector3 _direction;

        private Rigidbody2D _rigidbody;
        private Transform _playerTransform;

        private EnemySpawner _enemySpawner;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        private void Start() => _health = maxHealth;

        private void FixedUpdate()
        {
            if (_playerTransform == null) return;

            _direction = (_playerTransform.position - transform.position).normalized;
            transform.right = _direction;
            _rigidbody.AddForce(_direction * speed * 10f, ForceMode2D.Force);
        }

        public void Setup(EnemySpawner enemySpawner, Transform playerTransform)
        {
            _enemySpawner = enemySpawner;
            _playerTransform = playerTransform;
        }

        public void TakeDamage(Vector2 direction, int damage)
        {
            _rigidbody.AddForce(direction, ForceMode2D.Impulse);
            _health -= damage;

            if (_health > 0) return;

            _enemySpawner.RegisterDead();
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}