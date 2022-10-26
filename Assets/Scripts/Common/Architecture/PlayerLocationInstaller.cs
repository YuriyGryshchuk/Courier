using UnityEngine;
using Zenject;

public class PlayerLocationInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        BindPlayerMover();
    }

    private void BindPlayerMover()
    {
        PlayerMover playerMover = Container
            .InstantiatePrefabForComponent<PlayerMover>(_playerPrefab, new Vector3(0, 1, 0), Quaternion.identity, null);
        Container
            .Bind<PlayerMover>().FromInstance(playerMover).AsSingle().NonLazy();
    }
}