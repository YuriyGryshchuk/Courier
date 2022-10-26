using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(PlarformSpeedChanger))]  
public class PlatformGenerator : MonoBehaviour
{
    private float _platformSpeed;
    private PlarformSpeedChanger _speedChanger;
    private List<GameObject> _pullPlatforms = new List<GameObject>();
    private float _platformSizeZ;
    private PlatformConfig _platformConfig;

    public event UnityAction PlatformDesrtoyed;
    public event UnityAction<GameObject> PlatformSpawned;
    private PullObjectGenerator _pullObjectGenerator = new PullObjectGenerator();

    [Inject]
    private void Construct(PlatformConfig platformConfig)
    {
        _platformConfig = platformConfig;
    }

    private void Start()
    {
        Init();
        CreatePullPlatforms();
        FindPlatformSizeZ();
        CreateStartLevel();
    }

    private void Init()
    {
        _speedChanger = GetComponent<PlarformSpeedChanger>();
        _speedChanger.SpeedChanged += SpeedChange;
        _platformSpeed = _speedChanger.GetStartPlatformSpeed();
    }

    private void CreatePullPlatforms()
    {
        _pullPlatforms = 
            _pullObjectGenerator.CreatePullObject(_platformConfig.Platforms, _platformConfig.PlatformCountInPull);
    }

    private void FindPlatformSizeZ()
    {
        _platformSizeZ = _pullPlatforms[0].GetComponent<BoxCollider>().size.z;
    }

    private void CreateStartLevel()
    {
        for (int i = 0; i < _platformConfig.StartPlaformCount; i++)
        {
            SpawnPlatform(i, 0f);
        }
    }

    private void SpawnPlatform(int i, float positionDifference)
    {
        GameObject platform = _pullPlatforms[Random.Range(0, _pullPlatforms.Count - 1)];
        if (!platform.activeSelf)
        {
            platform.SetActive(true);
            platform.transform.position = new Vector3(0, 0, i * _platformSizeZ - positionDifference);
            platform.GetComponent<PlatformMover>().Init(_platformSpeed, this, _platformSizeZ, _speedChanger);
            PlatformSpawned?.Invoke(platform);
        }
        else 
            SpawnPlatform(i, positionDifference);
    }

    public void DestroyPlatform(GameObject platform, float positionDifference)
    {
        platform.SetActive(false);
        PlatformDesrtoyed?.Invoke();
        SpawnPlatform(_platformConfig.StartPlaformCount - 1, positionDifference);
    }

    private void SpeedChange(float currentPlatformSpeed)
    {
        _platformSpeed = currentPlatformSpeed;
    }

    private void OnDisable()
    {
        _speedChanger.SpeedChanged -= SpeedChange;
    }
}
