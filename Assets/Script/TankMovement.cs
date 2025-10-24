using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference rotate;
    public InputActionReference rotateTop;

    public GameObject top;
    public float moveSpeed;
    public float rotateSpeed;
    public float rotateTopSpeed;
	public Rigidbody rb;
	public float uprightCorrectionSpeed = 5f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
    {
        var _rotateAction = rotate.action.ReadValue<float>();
        var _rotateTopAction = rotateTop.action.ReadValue<float>();
        var _moveAction = move.action.ReadValue<float>();

		Vector3 moveDirection = transform.forward * _moveAction * moveSpeed;
		rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

		top.transform.Rotate(0, _rotateTopAction * rotateTopSpeed * Time.deltaTime, 0);

		Quaternion rotation = Quaternion.Euler(0, _rotateAction * rotateSpeed *Time.deltaTime, 0);
		rb.MoveRotation(rb.rotation * rotation);		
		CorrectPosition();
	}
	void CorrectPosition()
	{
		Vector3 uprightDirection = Vector3.up;
		Vector3 tankUpDirection = transform.up;

		Quaternion correctionRotation = Quaternion.FromToRotation(tankUpDirection, uprightDirection) * rb.rotation;
		rb.rotation = Quaternion.Lerp(rb.rotation, correctionRotation, uprightCorrectionSpeed * Time.fixedDeltaTime);
	}
}
