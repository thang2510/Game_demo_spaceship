using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class CanPickAble : MyMonobehavior
{
    [SerializeField] protected CircleCollider2D _collider;

    protected override void Reset()
    {
        base.Reset();
        this.LoadTrigger();
    }


    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true; // Bật trigger
        this._collider.radius = 0.2f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

}
