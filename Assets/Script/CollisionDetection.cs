using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	private const string TAG = "Bullet";
	private Transform _spawnPosition;
	private TargetSpawner _targetSpawner;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(TAG)) {
			ScoreManager.Score += 10;
			Destroy(collision.gameObject);
			Destroy(gameObject, 0.5f);
			_targetSpawner.RemoveElementFromList(this, _spawnPosition);
		}
	}

	public void Initialize(TargetSpawner spawner, Transform pos)
	{
		_spawnPosition = pos;
		_targetSpawner = spawner;
	}
}
