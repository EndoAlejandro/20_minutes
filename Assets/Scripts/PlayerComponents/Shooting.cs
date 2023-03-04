using Input;
using UnityEngine;

namespace PlayerComponents
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Transform weapon;
        [SerializeField] private Bullet bullet;

        [SerializeField] private float timeBetweenShooting = 0.5f;

        private float _shootTimer;

        private Vector2 _aimDirection;
        private Transform _crossHair;

        private void Update()
        {
            if (_crossHair == null)
            {
                _crossHair = FindObjectOfType<CrossHair>().transform;
                return;
            }

            Aiming();
            Shoot();
        }

        private void Shoot()
        {
            if (_shootTimer > 0) _shootTimer -= Time.deltaTime;

            if (InputReader.Instance.Shoot && _shootTimer <= 0)
            {
                _shootTimer = timeBetweenShooting;
                var b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.Setup(_aimDirection, 2f, 3f);
            }
        }

        private void Aiming()
        {
            _aimDirection = (_crossHair.position - transform.position).normalized;
            weapon.right = _aimDirection;
        }
    }
}