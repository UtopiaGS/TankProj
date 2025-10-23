using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference rotate;
    public InputActionReference rotateTop;

    public GameObject top;
    public float moveSpeed;
    public float rotateSpeed;
    public float rotateTopSpeed;

    public float uprightCorrectionSpeed = 5f;
    public Rigidbody rb;

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

        Quaternion rotation = Quaternion.Euler(0, _rotateAction * rotateSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
        CorrectPosition();
        RotateTop();

	}

	void CorrectPosition()
	{
		Quaternion targetRotation = Quaternion.Euler(0, rb.rotation.eulerAngles.y, 0);
        rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, uprightCorrectionSpeed * Time.fixedDeltaTime);
	}

    void RotateTop() {
        Vector3 mousePosition = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
		{
			Vector3 targetPosition = hitInfo.point;

			Vector3 directionToTarget = targetPosition - top.transform.position;

            directionToTarget.y = 0;

            if (directionToTarget.magnitude > 0.01f) {
				Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                Quaternion bodyRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

				Quaternion finalRotation = bodyRotation * Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

                top.transform.rotation = Quaternion.Lerp(top.transform.rotation, finalRotation, rotateTopSpeed * Time.fixedDeltaTime);
			}
		}

	}
}
