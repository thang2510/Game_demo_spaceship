using UnityEngine;

public class shipShoot : MonoBehaviour
{
    [SerializeField] Transform BulletFiring;
    [SerializeField] protected bool isshooting = false;
    [SerializeField] protected float ShootTimer = 0f;
    [SerializeField] protected float ShootDelay = 0.06f;
    [SerializeField] string NameBullet = "bullet_2";

    private void Reset()
    {
        this.BulletFiring = GameObject.Find("BulletFiring").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.Shoot();
        this.Checkshoot();
    }
    void Shoot()
    {
        if (!isshooting) return;
        ShootTimer += Time.fixedDeltaTime;
        if (ShootTimer < ShootDelay) return;
        ShootTimer = 0f;
        Transform bullet = BulletSpawner.instance.Spawn(this.NameBullet, this.transform.position, this.transform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.transform.parent = this.BulletFiring;
    }
    private bool Checkshoot()
    {
        isshooting= InputManager.instance.getMouseDelta;
        return isshooting;
    }
}
