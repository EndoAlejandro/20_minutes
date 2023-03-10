using System.Collections;
using PlayerComponents;
using UnityEngine;

public class ExperiencePoint : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask playerLayerMask;

    private bool _playerFound;

    private Collider2D[] _results;

    private void Awake() => _results = new Collider2D[3];

    private void Update()
    {
        if (_playerFound) return;

        var amount = Physics2D.OverlapCircleNonAlloc(transform.position, 5f, _results, playerLayerMask);
        for (int i = 0; i < amount; i++)
        {
            if (!_results[i].TryGetComponent(out Player player)) continue;

            _playerFound = true;
            StartCoroutine(GoToPlayer(player));
        }
    }

    private IEnumerator GoToPlayer(Player player)
    {
        var playerTransform = player.transform;

        while (Vector2.Distance(playerTransform.position, transform.position) > 0.5f)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, Time.deltaTime * speed);
            yield return null;
        }

        player.AddXp();
        Destroy(gameObject);
    }
}