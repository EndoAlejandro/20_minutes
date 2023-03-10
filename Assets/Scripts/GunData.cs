using UnityEngine;

[CreateAssetMenu(menuName = "Create GunData", fileName = "NewGunData", order = 0)]
public class GunData : ScriptableObject
{
    [SerializeField] private Sprite art;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private float knockBackForce;
    [SerializeField] private int bulletsPerShot;
    [SerializeField] private int clipSize;

    public Sprite Art => art;
    public float Damage => damage;
    public float BulletSpeed => bulletSpeed;
    public float BulletLifeTime => bulletLifeTime;
    public float KnockBackForce => knockBackForce;
    public int BulletsPerShot => bulletsPerShot;
    public int ClipSize => clipSize;
}