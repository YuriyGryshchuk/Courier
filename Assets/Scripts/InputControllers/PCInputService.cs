using UnityEngine;
using UnityEngine.Events;

public class PCInputService : MonoBehaviour, IInputService
{
    public event UnityAction<float> MovedPlayerX;

    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x != 0)
            MovedPlayerX?.Invoke(x);
    }
}
