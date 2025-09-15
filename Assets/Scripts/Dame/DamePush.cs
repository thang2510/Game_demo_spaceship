using UnityEngine;

public class DamePush : MyMonobehavior
{
    [SerializeField] protected float Dame = 1f;
    public virtual void Send(GameObject gameObject)
    {
        gameObject = gameObject.transform.parent.gameObject;
        DameGet dameGet = gameObject.GetComponentInChildren<DameGet>();
        if (dameGet == null) return;
        this.Send(dameGet);
    }
    public virtual void Send(DameGet dameGet)
    {
        dameGet.Deduct(this.Dame);
    }
}
