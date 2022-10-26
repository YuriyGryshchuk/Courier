using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EntityGenerator : MonoBehaviour
{
    private List<GameObject> _pullEntity = new List<GameObject>();
    private EnemyConfig _enemyConfig;
    private PlayerConfig _playerConfig;
    private PlatformGenerator _platformGenerator;
    private Vector3 _startPosition;
    private Vector3 _rightPosition;
    private Vector3 _leftPosition;

    private PullObjectGenerator _pullObjectGenerator = new PullObjectGenerator();

    [Inject]
    private void Construct(EnemyConfig enemyConfig, PlayerConfig playerConfig, PlatformGenerator platformGenerator)
    {
        _enemyConfig = enemyConfig;
        _playerConfig = playerConfig;
        _platformGenerator = platformGenerator;
    }

    private void Start()
    {
        Init();
        CreatePullEntity();
        SetPositions();
    }

    private void Init()
    {
        _platformGenerator.PlatformSpawned += RandomizeEntityPerLine;
    }

    private void RandomizeEntityPerLine(GameObject platform)
    {
        int currentChanceSecondSpawn = Random.Range(0, 100);
        if (currentChanceSecondSpawn <= _enemyConfig.ChanceSecondSpawn)
        {
            RandomizePositionOnLine(platform, 2);
        }
        else
            RandomizePositionOnLine(platform, 1);
    }

    private void RandomizePositionOnLine(GameObject platform, int entityPerLine)
    {
        int namberPosition = Random.Range(0, 3);
        SpawnOnPosition(platform, namberPosition);
        if (entityPerLine == 2)
        {
            RandomizeSecondPosition(platform, namberPosition);
        }
    }

    private void RandomizeSecondPosition(GameObject platform, int namberPosition)
    {
        int namberSecondPosition = Random.Range(0, 3);
        if (namberSecondPosition == namberPosition)
        {
            RandomizeSecondPosition(platform, namberPosition);
        }
        else
            SpawnOnPosition(platform, namberSecondPosition);
    }

    private void SpawnOnPosition(GameObject platform, int namberPosition)
    {
        switch (namberPosition)
        {
            case 0:
                SpawnEntity(_startPosition, platform);
                break;
            case 1:
                SpawnEntity(_rightPosition, platform);
                break;
            case 2:
                SpawnEntity(_leftPosition, platform);
                break;
        }
    }

    private void CreatePullEntity()
    {
        _pullEntity =
            _pullObjectGenerator.CreatePullObject(_enemyConfig.Enemies, _enemyConfig.EnemyCountInPull);
    }

    private void SetPositions()
    {
        _startPosition = new Vector3(0, 0, 0);
        _rightPosition = new Vector3(_playerConfig.DistanseWithoutPositions, _startPosition.y, _startPosition.z);
        _leftPosition = new Vector3(-_playerConfig.DistanseWithoutPositions, _startPosition.y, _startPosition.z);
    }

    private void SpawnEntity(Vector3 spawnPosition, GameObject currentPlatform)
    {
        GameObject entity = _pullEntity[Random.Range(0, _pullEntity.Count - 1)];
        if (!entity.activeSelf)
        {
            entity.SetActive(true);
            entity.transform.position = new Vector3(spawnPosition.x, 1, currentPlatform.GetComponent<Transform>().position.z);
            entity.GetComponent<EntityMover>().Init(_platformGenerator);
        }
        else
            SpawnEntity(spawnPosition, currentPlatform);
    }

    private void OnDestroy()
    {
        _platformGenerator.PlatformSpawned -= RandomizeEntityPerLine;
    }
}
