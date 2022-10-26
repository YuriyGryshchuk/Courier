using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField]
    private float _distanseWithoutPositions;
    [SerializeField]
    private float _timeWithoutMove;

    public float DistanseWithoutPositions { get; private set; }
    public float TimeWithoutMove { get; private set; }

    private void Awake()
    {
        SetProperty();
    }

    private void SetProperty()
    {
        DistanseWithoutPositions = _distanseWithoutPositions;
        TimeWithoutMove = _timeWithoutMove;
    }
}
