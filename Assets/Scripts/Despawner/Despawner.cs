using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : MyMonobehavior
{
    protected virtual void despawn()
    {
        if (this.canDespawn())
        {
            //this.transform.parent = this.Pool;
            //BulletSpawner.instance.ReturnToPool(this.transform); // <-- Thêm dòng này
            //this.gameObject.SetActive(false);
        }
    }

    protected abstract bool canDespawn();
}
