using Input;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private void Awake() => Cursor.visible = false;
    private void Update() => transform.position = InputReader.Instance.MouseWorld;
}
