using UnityEngine;

public class BulletSpawner : Spawner
{
    public static BulletSpawner instance;
    protected override void Awake()
    {
        instance = this;
    }

}
