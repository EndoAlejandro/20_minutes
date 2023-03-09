using System;
using System.Collections;
using EnemyComponents;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _speed;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    private void Update() => _rigidbody.velocity = _direction * _speed;

    public void Setup(Vector2 direction, float speed, float lifeTime)
    {
        _direction = direction;
        _speed = speed;
        StartCoroutine(LifeTime(lifeTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Enemy enemy)) enemy.TakeDamage(_direction * _speed * 0.1f,1);
        BulletCollide();
    }

    private IEnumerator LifeTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        BulletCollide();
    }

    private void BulletCollide() => Destroy(gameObject);
}