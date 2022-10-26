using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerConfig _playerConfig;
    [SerializeField]
    private PlatformConfig _platformConfig;
    [SerializeField]
    private GameLogicConfig _gameLogicConfig;
    [SerializeField]
    private EnemyConfig _enemyConfig;

    public override void InstallBindings()
    {
        BindPlayerConfig();
        BindPlatformConfig();
        BindGameLogicConfig();
        BindEnemyConfig();
    }

    private void BindEnemyConfig()
    {
        Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
    }

    private void BindGameLogicConfig()
    {
        Container.Bind<GameLogicConfig>().FromInstance(_gameLogicConfig).AsSingle();
    }

    private void BindPlayerConfig()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }

    private void BindPlatformConfig()
    {
        Container.Bind<PlatformConfig>().FromInstance(_platformConfig).AsSingle();
    }
}