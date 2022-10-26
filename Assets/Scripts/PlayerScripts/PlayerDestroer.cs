using UnityEngine;
using Zenject;

public class PlayerDestroer : MonoBehaviour
{
    private MainCamera _mainCamera;
    private EndGameCanvasCamera _endGameCanvasCamera;

    [Inject]
    private void Construct(MainCamera mainCamera, EndGameCanvasCamera endGameCanvasCamera)
    {
        _mainCamera = mainCamera;
        _endGameCanvasCamera = endGameCanvasCamera;
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        SwitchCameraToEndGame();
    }

    private void SwitchCameraToEndGame()
    {
        _mainCamera.gameObject.SetActive(false);
        _endGameCanvasCamera.gameObject.SetActive(true);
    }
}
