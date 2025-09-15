using UnityEngine;

public abstract class DameGet : MyMonobehavior
{
    [SerializeField] protected float hp;
    [SerializeField] protected float hpMax;
    [SerializeField] EnemyCtr EnemyCtr;
    [SerializeField] Transform Pool;
    protected virtual void Reborn()
    {
        this.hp = this.hpMax;
    }

    public void Add(float AddHp)
    {
        this.hp += AddHp;
        if (hp > this.hpMax) hp = this.hpMax;
    }
    public void Deduct(float DeductHp)
    {
        this.hp -= DeductHp;
        if (hp < 0) hp = 0;

        Debug.Log($"{gameObject.name} bị trúng đạn, máu còn lại: {hp}");

        if (CheckIsDead())
        {
            Ondead();
            Debug.Log($"{gameObject.name} đã chết!");
            this.transform.parent.parent = this.Pool;
            EnemySpawner.instance.ReturnToPool(this.transform.parent);
            this.transform.parent.gameObject.SetActive(false);
            EnemyCtr.countEnemy--;
        }
    }

    protected abstract void Ondead();
    
    protected bool CheckIsDead()
    {
        return hp <= 0;
    }

}
