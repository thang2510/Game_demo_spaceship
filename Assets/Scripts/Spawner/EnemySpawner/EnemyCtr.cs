using UnityEngine;

public class EnemyCtr : MonoBehaviour
{
    [SerializeField] protected Transform EnemySpawning;
    [SerializeField] protected Transform SpawnPoint;
    [SerializeField] protected int CountLimit = 10;
    public static int countEnemy = 0;
    [SerializeField] protected float ShootTimer = 0f;
    [SerializeField] protected float ShootDelay = 2f;
    private void Awake()
    {
        this.EnemySpawning = GameObject.Find("EnemySpawning").transform;
        this.SpawnPoint = GameObject.Find("SpawnPoint").transform;

    }
    private void Reset()
    {
        this.EnemySpawning = GameObject.Find("EnemySpawning").transform;
        this.SpawnPoint = GameObject.Find("SpawnPoint").transform;

    }
    private void Update()
    {
        
        spawnEnemy();
    }
   
    protected virtual void spawnEnemy()
    {
        ShootTimer += Time.fixedDeltaTime;
        if (ShootTimer < ShootDelay) return;
        ShootTimer = 0f;
        if (countEnemy >= CountLimit) return;
        if (SpawnPoint == null || SpawnPoint.childCount == 0) return;
        // Lấy random 1 child trong SpawnPoint
        int index = Random.Range(0, SpawnPoint.childCount);
        Transform posspawn = SpawnPoint.GetChild(index);
        // random tên enemy trong ListPrefabs
        int indexEnemy = Random.Range(0, EnemySpawner.instance.ListPrefabsCount);
        string enemyName = EnemySpawner.instance.GetPrefabName(indexEnemy);

        Transform enemy = EnemySpawner.instance.Spawn(enemyName, posspawn.position, transform.rotation);

        enemy.gameObject.SetActive(true);
        enemy.transform.parent = this.EnemySpawning;
        countEnemy++;
        // Chỉ gọi lại spawn nếu chưa đạt limit
    }

}
