using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference rotate;

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
        var _moveAction = move.action.ReadValue<float>();

		Vector3 moveDirection = transform.forward * _moveAction * moveSpeed;
		rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);


		Quaternion rotation = Quaternion.Euler(0, _rotateAction * rotateSpeed *Time.deltaTime, 0);
		rb.MoveRotation(rb.rotation * rotation);		
		CorrectPosition();
		RotateTop();

	}
	void CorrectPosition()
	{
		Vector3 uprightDirection = Vector3.up;
		Vector3 tankUpDirection = transform.up;

		Quaternion correctionRotation = Quaternion.FromToRotation(tankUpDirection, uprightDirection) * rb.rotation;
		rb.rotation = Quaternion.Lerp(rb.rotation, correctionRotation, uprightCorrectionSpeed * Time.fixedDeltaTime);
	}

	private void RotateTop() {
		Vector3 mousePosition = Input.mousePosition;

		Ray ray = Camera.main.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
			Vector3 targetPosition = hit.point;

			Vector3 direction = targetPosition - top.transform.position;

			direction.y = 0;

			if (direction.magnitude > 0.02f) {
				Quaternion targetRotation = Quaternion.LookRotation(direction);

				Quaternion bodyRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

				Quaternion finalRotation = bodyRotation * Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

				top.transform.rotation = Quaternion.Lerp(top.transform.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
			}
		}
	}
}
