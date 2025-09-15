using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,target.position,speed *Time.deltaTime);
    }
}
