using UnityEngine;

public class PlatformConfig : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platforms;
    [SerializeField]
    private byte _startPlaformCount;
    [SerializeField]
    private byte _platformCountInPull;
    [SerializeField]
    private float _startPlatformSpeed;
    [SerializeField]
    private float _speedModifier;

    public GameObject[] Platforms { get; private set; }
    public byte StartPlaformCount { get; private set; }
    public byte PlatformCountInPull { get; private set; }
    public float StartPlatformSpeed { get; private set; }
    public float SpeedModifier { get; private set; }

    private void Awake()
    {
        SetProperty();
    }
    private void SetProperty()
    {
        Platforms = _platforms;
        StartPlaformCount = _startPlaformCount;
        PlatformCountInPull = _platformCountInPull;
        StartPlatformSpeed = _startPlatformSpeed;
        SpeedModifier = _speedModifier;
    }
}
