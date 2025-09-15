using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : Spawner
{
    public static ItemSpawner instance;
    protected override void Awake()
    {
        instance = this;
    }
    public virtual void Drop(float rate,List<Item> list)
    {
        Debug.Log(list[0].ItemSO.ItemCode.ToString());
    }
}
