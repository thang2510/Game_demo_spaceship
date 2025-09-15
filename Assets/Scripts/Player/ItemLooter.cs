using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : MyMonobehavior
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] Transform Pool;
    protected override void Reset()
    {
        base.Reset();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
        this.LoadItemSpawning();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " LoadInventory", gameObject);
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

    protected virtual void LoadItemSpawning()
    {
        this.Pool = GameObject.Find("Pool").transform;
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        CanPickAble canPickAble = collision.GetComponent<CanPickAble>();
        if (canPickAble == null) return;

        Debug.Log(collision.name);
        Debug.Log(collision.transform.parent.name);
        Debug.Log("Co the pick");
        Inventory.instance.AddItem(collision.transform.parent.name);
        collision.transform.parent.gameObject.SetActive(false);
        collision.transform.parent.transform.parent = this.Pool;
    }
}
