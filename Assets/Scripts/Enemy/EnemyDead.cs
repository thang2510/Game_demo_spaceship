using UnityEngine;

public class EnemyDead : DameGet
{
    [SerializeField] protected string FxName = "Smoke";
    [SerializeField] protected Transform FxSpawning;
    [SerializeField] protected Transform ItemSpawning;
    [SerializeField] protected EnemySO EnemySO;
    
    protected override void Reset()
    {
        base.Reset();
        if (EnemySO != null) return;
        string repath = "Enemy/" + transform.parent.transform.name;
        this.EnemySO = Resources.Load<EnemySO>(repath);
        FxSpawning = GameObject.Find("FxSpawning").transform;
        ItemSpawning = GameObject.Find("ItemSpawning").transform;
        Reborn();
    }

    protected override void Awake()
    {
        base.Awake();
        if (EnemySO != null) return;
        string repath = "Enemy/" + transform.parent.transform.name;
        this.EnemySO = Resources.Load<EnemySO>(repath);
        Reborn();
    }
    protected override void Ondead()
    {
        this.Ondeadfx();
        this.OnDeadDropItem();
    }
    protected virtual void Ondeadfx()
    {

        Transform newSmokefx = FxSpawner.instance.Spawn(this.FxName, this.transform.position, this.transform.rotation);

        newSmokefx.gameObject.SetActive(true);
        newSmokefx.transform.parent = FxSpawning;
    }
    protected virtual void OnDeadDropItem()
    {
        Vector3 pos = this.transform.position;
        Quaternion rot = new Quaternion(0f,0f,0f,0f);
        Transform newItem = ItemSpawner.instance.Spawn(EnemySO.ListItem[0].ItemSO.ItemCode.ToString(),pos,rot);
        newItem.gameObject.SetActive(true);
        newItem.transform.parent = ItemSpawning;
    }
    protected override void Reborn()
    {

        this.hpMax = this.EnemySO.HpMax;
        this.hp = this.hpMax;
    }

}
