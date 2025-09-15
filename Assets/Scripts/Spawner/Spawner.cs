using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class Spawner : MyMonobehavior
{
    [SerializeField] List<Transform> ListPrefabs;
    public int ListPrefabsCount => ListPrefabs.Count;
    [SerializeField] List<Transform> Pool;

    protected override void Reset()
    {
        this.Loadcomponents();
        this.ResetPoolBullet();
    }
    protected override void Loadcomponents()
    {
        this.LoadpreFabs();
    }
    protected void LoadpreFabs()
    {
        Transform Listprefabs = transform.Find("ListPrefabs");
        if (this.ListPrefabs.Count > 0) return;
        foreach (Transform prefabobj in Listprefabs)
        {
            ListPrefabs.Add(prefabobj);
            this.Hideobj(prefabobj);
        }
        Debug.Log(transform.name + ": loadPrefabs, ", gameObject);

    }
    protected void ResetPoolBullet()
    {
        this.Pool.Clear();
    }
    protected void Hideobj(Transform obj)
    {
        obj.gameObject.SetActive(false);
    }
    public virtual Transform Spawn(string PrefabsName, Vector3 position, quaternion rotation)
    {
        Transform newPrefab = GetTransformByName(PrefabsName);
        Transform newObj = null;
        Transform pooled = CheckObjectInPool(newPrefab);
        if (pooled != null)
        {
            newObj = pooled;
            newObj.position = position;
            newObj.rotation = rotation;
            newObj.gameObject.SetActive(true);
        }
        else
        {
            newObj = Instantiate(newPrefab, position, rotation);
            newObj.name = PrefabsName;
        }
        return newObj;
    }
    protected virtual Transform CheckObjectInPool(Transform newPrefab)
    {
        foreach (Transform prefabs in this.Pool)
        {
            if (newPrefab.name == prefabs.name)
            {
                this.Pool.Remove(prefabs);
                return prefabs;
            }
        }
        return null;
    }

    //protected virtual void Despawn(Transform transform)
    //{
    //    this.Pool.Remove(transform);
    //    this.transform.gameObject.SetActive(false);
    //    this.transform.parent = null;
    //}
    protected virtual Transform GetTransformByName(string name)
    {
        foreach (Transform Obj in ListPrefabs)
        {
            Debug.Log("Checking prefab: " + Obj.name); // debug tên
            if (Obj.name == name) return Obj;
        }
        Debug.LogError("Không tìm thấy prefab có tên: " + name);
        return null;
    }
    public string GetPrefabName(int index)
    {
        if (index < 0 || index >= ListPrefabs.Count) return null;
        return ListPrefabs[index].name;
    }

    public void ReturnToPool(Transform Obj)
    {
        if (!this.Pool.Contains(Obj))
        {
            this.Pool.Add(Obj);
        }
    }
}
