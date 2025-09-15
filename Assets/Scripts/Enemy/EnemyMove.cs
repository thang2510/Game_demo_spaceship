using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] protected float speed_enemy = 1f;
    [SerializeField] protected Transform player;
    [SerializeField] protected Vector3 target_position;
    [SerializeField] protected Vector3 Direction;
    [SerializeField] protected Transform Model;
    [SerializeField] protected float Rotationrate =10f;

    private void OnEnable()
    {
        // Lấy vị trí mục tiêu ngay lúc spawn
        target_position = player.position;

        // Tính hướng bay ban đầu
        Direction = (target_position - transform.position).normalized;
    }
    private void Update()
    {
        lookAtTarget();
        MoveToTarget();
    }

    void lookAtTarget()
    {
        Vector3 dir = player.position - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, Rotationrate * Time.deltaTime);
    }

    void MoveToTarget()
    {
        // Di chuyển theo hướng bay ban đầu
        Vector3 move = Direction * speed_enemy * Time.deltaTime;
        transform.parent.Translate(move, Space.World);

        // Giữ Z = 0
        Vector3 pos = transform.parent.position;
        pos.z = 0;
        transform.parent.position = pos;
    }


   

}
