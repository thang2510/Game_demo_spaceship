using UnityEngine;

public class ItemDespawner : DespawnByDistance
{
    [SerializeField] Transform Pool;
    protected override void Reset()
    {
        MaxDistance = 20f;
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
            ItemSpawner.instance.ReturnToPool(this.transform); // <-- Thêm dòng này
            this.gameObject.SetActive(false);
        }
    }
}
