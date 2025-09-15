using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] Transform Pool;
    protected override void Reset()
    {
        MaxDistance = 30f;
        this.Pool = transform.parent.parent.Find("Pool");
    }
    private void Update()
    {
        checkvalueDistance();
        despawn();
    }
    protected override void despawn()
    {
        if (canDespawn())
        {
            this.transform.parent = this.Pool;
            BulletSpawner.instance.ReturnToPool(this.transform); // <-- Thêm dòng này
            this.gameObject.SetActive(false);
        }

    }
}
