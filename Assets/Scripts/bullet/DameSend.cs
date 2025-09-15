using UnityEngine;

public class DameSend : MonoBehaviour
{
    [SerializeField] protected DamePush DamePush;
    [SerializeField] protected CircleCollider2D CircleCollider2D;
    [SerializeField] protected string HitBoxfx = "HitBox";
    [SerializeField] protected Transform FxDespawning;

    // ⚡ Thêm tham chiếu để lấy hướng bay từ script bullet_fly

    private void Reset()
    {
        LoadComponents();
        LoadColider();
    }

    protected void LoadComponents()
    {
        if (DamePush == null) DamePush = GetComponentInChildren<DamePush>();
    }

    protected void LoadColider()
    {
        if (CircleCollider2D != null) return;
        CircleCollider2D = GetComponent<CircleCollider2D>();
        CircleCollider2D.isTrigger = true; // vì bạn đang check trigger
        CircleCollider2D.radius = 0.05f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameGet canPickAble = collision.GetComponentInChildren<DameGet>();
        if (canPickAble == null) return;

        // Gửi dame
        DamePush?.Send(collision.gameObject);

        // Lấy vị trí va chạm
        Vector3 hitPos = collision.ClosestPoint(transform.position);

        // Lấy tâm enemy
        Vector3 enemyPos = collision.transform.position;

        // Vector từ va chạm -> enemy
        Vector3 dir = (enemyPos - hitPos).normalized;

        // Tính góc
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, angle);

        Debug.Log($"FX angle: {angle}");

        // Spawn FX
        if (!string.IsNullOrEmpty(HitBoxfx) && FxSpawner.instance != null)
        {
            Transform hitbox = FxSpawner.instance.Spawn(HitBoxfx, hitPos, rot);
            if (hitbox != null)
            {
                hitbox.gameObject.SetActive(true);
                if (FxDespawning != null)
                    hitbox.transform.parent = FxDespawning;
            }
        }

        Destroy(transform.gameObject); // hủy luôn parent (EmptyObj bullet)
    }
}
