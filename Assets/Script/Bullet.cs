using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
  

    void LateUpdate()
    {
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
