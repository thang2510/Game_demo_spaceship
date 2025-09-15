using UnityEngine;

public class DespawnByDistance : Despawner
{
    [SerializeField] protected float Distance;
    [SerializeField] protected float MaxDistance = 30f;

    protected override bool canDespawn()
    {
        return Distance > MaxDistance;
    }
    protected override void Reset()
    {
        base.Reset();
        this.Loadcomponents();
    }
    protected override void Loadcomponents()
    {
        base.Loadcomponents();
     
    }
   
    protected void checkvalueDistance()
    {
        this.Distance = Vector3.Distance(this.transform.position, GameManager.instance.maincamera.transform.position);
    }
}
