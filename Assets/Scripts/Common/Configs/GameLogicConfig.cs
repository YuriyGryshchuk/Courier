using UnityEngine;

public class GameLogicConfig : MonoBehaviour
{
    [SerializeField]
    private int _scorePerPlatform;

    public int ScorePerPlatform { get; private set; }

    private void Awake()
    {
        SetProperty();
    }

    private void SetProperty()
    {
        ScorePerPlatform = _scorePerPlatform;
    }
}
