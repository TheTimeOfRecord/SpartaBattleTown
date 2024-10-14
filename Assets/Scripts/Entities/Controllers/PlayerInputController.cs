using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    protected override void Awake()
    {
        camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        CallMoveEvent(direction);
    }
    public void OnLook(InputValue value)
    {
        Vector2 mouseWorldPos = camera.ScreenToWorldPoint(value.Get<Vector2>());
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;
        CallMLookEvent(direction);
    }
    public void OnMouseLeft()
    {

    }
}
