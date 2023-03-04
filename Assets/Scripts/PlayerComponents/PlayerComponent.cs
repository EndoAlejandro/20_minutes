using UnityEngine;

namespace PlayerComponents
{
    public abstract class PlayerComponent : MonoBehaviour
    {
        protected Player Player { get; private set; }
        protected Rigidbody2D Rigidbody { get; private set; }

        protected virtual void Awake()
        {
            Player = GetComponent<Player>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}