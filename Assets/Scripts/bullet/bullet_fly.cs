using UnityEngine;

public class bullet_fly : MonoBehaviour
{
    [SerializeField] public Vector3 Direction = Vector3.right;
    [SerializeField] protected float speed_bullet = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(Direction* speed_bullet*Time.deltaTime);
        
    }

}
