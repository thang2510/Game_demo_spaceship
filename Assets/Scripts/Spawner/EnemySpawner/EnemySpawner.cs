using UnityEngine;

public class EnemySpawner : Spawner
{
    public static EnemySpawner instance;
    protected override void Awake()
    {
        instance = this;
    }
}
