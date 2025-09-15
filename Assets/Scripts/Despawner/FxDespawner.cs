using UnityEngine;

public class FxDespawner : DespawnByTime
{
    [SerializeField] protected Transform Pool;

    protected override void Reset()
    {
        base.Reset();
        this.maxTimeAlive = 2f;
        this.Pool = this.transform.parent.parent.Find("Pool");

    }

    private void OnEnable()
    {
        this.timeAlive = 0f; // reset thời gian mỗi lần spawn lại
    }

    private void Update()
    {
        this.timeAlive += Time.deltaTime;
        this.despawn(); // dùng cơ chế của DespawnByTime
    }

    protected override void despawn()
    {
        if (canDespawn())
        {
            this.transform.parent = this.Pool;
            FxSpawner.instance.ReturnToPool(this.transform);
            this.gameObject.SetActive(false);
        }
    }
}
