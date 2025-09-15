using Unity.Mathematics;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField] protected Vector3 target_position;
    [SerializeField] protected float _speed = 10f;
    [SerializeField] protected float rotation_rate = 5f;

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        lookAtTarget();
    }
    void lookAtTarget()
    {
        Vector3 dir = target_position - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, rotation_rate * Time.deltaTime);
    }
    void MoveToTarget()
    {
        target_position = InputManager.instance.MouseDelta;
        this.transform.parent.position = Vector3.Lerp(this.transform.parent.position, target_position, _speed * Time.deltaTime);
    }
}
