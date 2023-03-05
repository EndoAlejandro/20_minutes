using Input;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private void Update() => transform.position = InputReader.Instance.MouseWorld;
}
