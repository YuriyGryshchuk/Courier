using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField]
    private MainCamera _mainCamera;
    [SerializeField] 
    private EndGameCanvasCamera _endGameCanvasCamera;

    public override void InstallBindings()
    {
        BindMainCamera();
        BindEndGameCanvasCamera();

    }

    private void BindEndGameCanvasCamera()
    {
        Container.Bind<EndGameCanvasCamera>().FromInstance(_endGameCanvasCamera).AsSingle();
    }

    private void BindMainCamera()
    {
        Container.Bind<MainCamera>().FromInstance(_mainCamera).AsSingle();
    }
}