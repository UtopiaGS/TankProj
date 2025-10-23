using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	private const string TAG = "Bullet";

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(TAG))
		{
			ScoreManager.Score += 10;
			Destroy(collision.gameObject);
			Destroy(gameObject, 0.5f);
			Debug.Log($"Score: {ScoreManager.Score}");
		}
	}
}
