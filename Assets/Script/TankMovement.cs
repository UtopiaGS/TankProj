using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference rotate;
    public InputActionReference rotateTop;

    public GameObject top;
    public float moveSpeed;
    public float rotateSpeed;
    public float rotateTopSpeed;
  
    void Update()
    {
        var _rotateAction = rotate.action.ReadValue<float>();
        var _rotateTopAction = rotateTop.action.ReadValue<float>();
        var _moveAction = move.action.ReadValue<float>();
        transform.Translate(0, 0, (_moveAction * moveSpeed * Time.deltaTime));

        top.transform.Rotate(0, _rotateTopAction * rotateTopSpeed * Time.deltaTime, 0);
        transform.Rotate(0, _rotateAction * rotateSpeed * Time.deltaTime, 0);
    }
}
