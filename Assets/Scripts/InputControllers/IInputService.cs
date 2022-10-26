using UnityEngine.Events;

public interface IInputService
{
    public event UnityAction<float> MovedPlayerX;

    void Update();
}
