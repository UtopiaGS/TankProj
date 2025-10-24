using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5f);
	}


	void FixedUpdate()
    {
		Vector3 moveDir = transform.forward * speed;
		rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime);
	}
}
