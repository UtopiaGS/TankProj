using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	private const string GROUND_TAG = "Ground";
	public float speed;
	Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5f);
	}
	void LateUpdate()
    {
		Vector3 moveDirection = transform.forward * speed;
		_rb.MovePosition(_rb.position + moveDirection * Time.deltaTime);

	}
	

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(GROUND_TAG))
		{
			Destroy(gameObject, 0.5f);
		}
	}
}
