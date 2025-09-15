using UnityEngine;

public class FxSpawner : Spawner
{
    public static FxSpawner instance;
    protected override void Awake()
    {
        instance = this;
    }
}
