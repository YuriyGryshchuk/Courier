using UnityEngine;
using Zenject;

public class GeneratorsInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _platformGeneratorPrefab;

    public override void InstallBindings()
    {
        BindPlatformGenerator();
    }

    private void BindPlatformGenerator()
    {
        Container.Bind<PlatformGenerator>().FromComponentInNewPrefab(_platformGeneratorPrefab).AsSingle().NonLazy();
    }
}