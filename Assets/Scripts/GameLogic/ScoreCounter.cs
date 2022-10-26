using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    private GameLogicConfig _logicConfig;
    private PlatformGenerator _platformGenerator;
    private int _score = 0;
    public event UnityAction<int> ScoreChanged;

    [Inject]
    private void Construct(PlatformGenerator platformGenerator, GameLogicConfig gameLogicConfig)
    {
        _logicConfig = gameLogicConfig;
        _platformGenerator = platformGenerator;
        _platformGenerator.PlatformDesrtoyed += ScoreCount;
    }
    private void ScoreCount()
    {
        _score += _logicConfig.ScorePerPlatform;
        ScoreChanged?.Invoke(_score);
    }

    private void OnDestroy()
    {
        _platformGenerator.PlatformDesrtoyed -= ScoreCount;
    }

}
