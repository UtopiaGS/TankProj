using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
  

    void LateUpdate()
    {
        transform.position += new Vector3(0,0,speed * Time.deltaTime);
    }
}
