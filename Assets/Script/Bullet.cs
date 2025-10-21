using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

  
    void LateUpdate()
    {
        Vector3 moveDirection = transform.forward * speed;
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);
    }
}
