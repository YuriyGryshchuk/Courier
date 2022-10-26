using UnityEngine;

public class EntityMover : MonoBehaviour
{
    private PlatformGenerator _platformGenerator;
    private float _currentSpeed;
    private Transform _entityTransform;

    public void Init(PlatformGenerator platformGenerator)
    {
        _platformGenerator = platformGenerator;
    }

    private void Start()
    {
        _platformGenerator.GetComponent<PlarformSpeedChanger>().SpeedChanged += SpeedChange;
        _entityTransform = GetComponent<Transform>();
    }

    private void SpeedChange(float currentSpeed)
    {
        _currentSpeed = currentSpeed;
    }

    private void Update()
    {
        _entityTransform.Translate(-transform.forward * _currentSpeed * Time.deltaTime);
        if (_entityTransform.position.z < -5)
            this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _platformGenerator.GetComponent<PlarformSpeedChanger>().SpeedChanged -= SpeedChange;
    }

}
