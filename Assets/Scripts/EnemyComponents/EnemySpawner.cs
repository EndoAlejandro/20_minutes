using System;
using System.Collections.Generic;
using PlayerComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyComponents
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy basicEnemy;

        [SerializeField] private float spawnDistance = 10f;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int maxEnemiesAmount = 5;

        private Transform _playerTransform;

        private int _enemiesInScene;

        private float _timer;

        private void Awake() => _playerTransform = FindObjectOfType<Player>().transform;

        private void Start() => _timer = spawnRate;

        private void Update()
        {
            if (_enemiesInScene > maxEnemiesAmount) return;

            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = spawnRate;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            _enemiesInScene++;
            var position = Random.insideUnitCircle.normalized * spawnDistance;
            var enemy = Instantiate(basicEnemy, position, Quaternion.identity);
            enemy.Setup(this, _playerTransform);
        }

        public void RegisterDead() => _enemiesInScene--;
    }
}