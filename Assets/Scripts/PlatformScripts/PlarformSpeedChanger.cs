using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlarformSpeedChanger : MonoBehaviour
{
    private int _speedPoint = 0;
    public event UnityAction<float> SpeedChanged;
    private float _platformSpeed;
    private PlatformConfig _platformConfig;

    [Inject]
    private void Construct(PlatformConfig platformConfig)
    {
        _platformConfig = platformConfig;
    }

    private void Awake()
    {
        StartCoroutine(SpeedPointCount());
    }

    private IEnumerator SpeedPointCount()
    {
        while (Time.timeScale == 1)
        {
            _speedPoint++;
            SpeedChange();
            yield return new WaitForSeconds(1);
        }
    }

    private void SpeedChange()
    {
        _platformSpeed = _platformConfig.StartPlatformSpeed + (_platformConfig.SpeedModifier * _speedPoint / 100);
        SpeedChanged?.Invoke(_platformSpeed);
    }

    public float GetStartPlatformSpeed()
    {
        return _platformConfig.StartPlatformSpeed;
    }
}
