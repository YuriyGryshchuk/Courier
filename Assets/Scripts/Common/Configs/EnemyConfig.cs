using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private float _enemyCountInPull;
    [SerializeField]
    [Range(0, 100)]
    private int _chanceSecondSpawn;

    public GameObject[] Enemies { get; private set; }
    public float EnemyCountInPull { get; private set; }
    public int ChanceSecondSpawn { get; private set; }

    private void Awake()
    {
        SetProperty();
    }

    private void SetProperty()
    {
        Enemies = _enemies;
        EnemyCountInPull = _enemyCountInPull;
        ChanceSecondSpawn = _chanceSecondSpawn;
    }
}
