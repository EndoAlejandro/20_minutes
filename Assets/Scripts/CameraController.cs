using PlayerComponents;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.001f, 0.5f)]
    [SerializeField] private float followStrength = 0.5f;

    private Transform _target;

    private Vector3 _targetPosition;

    private void LateUpdate()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<Player>().transform;
            return;
        }

        _targetPosition = Vector3.Lerp(transform.position, _target.position, followStrength);
        _targetPosition.z = transform.position.z;

        transform.position = _targetPosition;
    }
}