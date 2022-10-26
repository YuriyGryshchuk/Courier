using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private float _platformSpeed;
    private PlatformGenerator _platformGenerator;
    private Transform _platformTransform;
    private float _platformSizeZ;
    private PlarformSpeedChanger _speedChanger;

    private void Start()
    {
        _platformTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        MovePlatform();
    }

    public void Init(float platformSpeed, PlatformGenerator platformGenerator, float platformSizeZ, PlarformSpeedChanger speedChanger)
    {
        _platformSpeed = platformSpeed;
        _platformGenerator = platformGenerator;
        _platformSizeZ = platformSizeZ;
        _speedChanger = speedChanger;
        speedChanger.SpeedChanged += SpeedChange;
    }

    private void MovePlatform()
    {
        _platformTransform.Translate(-_platformTransform.forward * _platformSpeed * Time.deltaTime);
        if (_platformTransform.position.z <= -_platformSizeZ)
        {
            _speedChanger.SpeedChanged -= SpeedChange;
            _platformGenerator.DestroyPlatform(this.gameObject, -_platformSizeZ - _platformTransform.position.z);
        }
    }

    private void SpeedChange(float platformSpeed)
    {
        _platformSpeed = platformSpeed;
    }
}
