using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    private IInputService _currentInput;
    private Transform _playerTransform;
    private Vector3 _startPosition;
    private Vector3 _rightPosition;
    private Vector3 _leftPosition;
    private bool _isCanMove;
    private PlayerConfig _playerConfig;

    [Inject]
    private void Construct(IInputService currentInput, PlayerConfig playerConfig)
    {
        _currentInput = currentInput;
        _playerConfig = playerConfig;
    }

    private void Start()
    {
        Init();
        SetPositions();
    }

    private void Init()
    {
        _isCanMove = true;
        _playerTransform = GetComponent<Transform>();
        _currentInput.MovedPlayerX += PlayerMoveX;
    }

    private void SetPositions()
    {
        _startPosition = _playerTransform.position;
        _rightPosition = new Vector3(_playerConfig.DistanseWithoutPositions, _startPosition.y, _startPosition.z);
        _leftPosition = new Vector3(-_playerConfig.DistanseWithoutPositions, _startPosition.y, _startPosition.z);
    }

    private void PlayerMoveX(float x)
    {
        Debug.Log(x);
        if (_playerTransform.position == _startPosition && x > 0.1 && _isCanMove)
        {
            _playerTransform.position = _rightPosition;
            StartCoroutine(WaitToMove());
        }
        if (_playerTransform.position == _startPosition && x < -0.1 && _isCanMove)
        {
            _playerTransform.position = _leftPosition;
            StartCoroutine(WaitToMove());
        }
        if (_playerTransform.position == _rightPosition && x < -0.1 && _isCanMove)
        {
            _playerTransform.position = _startPosition;
            StartCoroutine(WaitToMove());
        }
        if (_playerTransform.position == _leftPosition && x > 0.1 && _isCanMove)
        {
            _playerTransform.position = _startPosition;
            StartCoroutine(WaitToMove());
        }
    }

     private IEnumerator WaitToMove()
    {
        _isCanMove = false;
        yield return new WaitForSeconds(_playerConfig.TimeWithoutMove);
        _isCanMove = true;
    }

    private void OnDisable()
    {
        _currentInput.MovedPlayerX -= PlayerMoveX;
    }
}
