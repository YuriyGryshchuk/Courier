using UnityEngine;
using Zenject;

public class GameLogicInstaller : MonoInstaller
{
    [SerializeField]
    private ScoreCounter _scoreCounterPrefab;

    public override void InstallBindings()
    {
        BindScoreCounter();
    }

    private void BindScoreCounter()
    {
        Container.Bind<ScoreCounter>().FromComponentInNewPrefab(_scoreCounterPrefab).AsSingle();
    }
}