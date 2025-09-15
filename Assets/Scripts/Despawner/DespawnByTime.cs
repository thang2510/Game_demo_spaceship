using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timeAlive = 0f;     // Thời gian sống
    [SerializeField] protected float maxTimeAlive = 2f;  // Tối đa 2 giây

    private void OnEnable()
    {
        this.timeAlive = 0f;   // Reset thời gian mỗi khi spawn lại từ pool
    }
    private void Update()
    {
        this.timeAlive += Time.deltaTime;  // Cộng dồn thời gian
        this.despawn();                    // Kiểm tra xem có despawn không
    }

    protected override bool canDespawn()
    {
        return this.timeAlive >= this.maxTimeAlive;
    }

    protected override void Reset()
    {
        base.Reset();
        this.timeAlive = 0f;   // reset lại khi object spawn lại
    }
}
