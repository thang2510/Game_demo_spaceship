using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] Transform BulletFiring;
    [SerializeField] protected float ShootTimer = 0f;
    [SerializeField] protected float ShootDelay = 5f;
    [SerializeField] string NameBullet = "bullet_1";

    private void Reset()
    {
        this.BulletFiring = GameObject.Find("BulletFiring").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.Shoot();
    }
    void Shoot()
    {
        ShootTimer += Time.fixedDeltaTime;
        if (ShootTimer < ShootDelay) return;
        ShootTimer = 0f;
        Transform bullet = BulletSpawner.instance.Spawn(this.NameBullet, this.transform.position, this.transform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.transform.parent = this.BulletFiring;
    }
    
}
