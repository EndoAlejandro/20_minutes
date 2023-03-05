namespace Weapons
{
    public class Gun
    {
        public float Damage { get; private set; }
        public float BulletSpeed { get; private set; }
        public float BulletLifeTime { get; private set; }
        public int BulletsPerShot { get; private set; }
        public int ClipSize { get; private set; }

        public Gun(GunData data)
        {
            Damage = data.Damage;
            BulletSpeed = data.BulletSpeed;
            BulletLifeTime = data.BulletLifeTime;
            BulletsPerShot = data.BulletsPerShot;
            ClipSize = data.ClipSize;
        }

        public void SetDamage(float damage) => Damage = damage;
        public void SetBulletSpeed(float bulletSpeed) => BulletSpeed = bulletSpeed;
        public void SetBulletLifeTime(float bulletLifeTime) => BulletLifeTime = bulletLifeTime;
        public void SetBulletsPerShot(int bulletsPerShot) => BulletsPerShot = bulletsPerShot;
        public void SetClipSize(int clipSize) => ClipSize = clipSize;
    }
}