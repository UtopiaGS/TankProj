using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private List<CollisionDetection> _targetList = new List<CollisionDetection>();
    [SerializeField] private List<Transform> _occupiedPositions = new List<Transform>();
    [SerializeField] private Transform[] _positions;

    [Header("Prefab")]
    [SerializeField] private CollisionDetection _target;


    void Start()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
           SpawnTarget(_positions[i]);
        }
    }

    private IEnumerator SpawnElementsRoutine(float waitTime) {

        yield return new WaitForSeconds(waitTime);
        Debug.Log($"Waited {waitTime} seconds");
        for (int i = 0; i < _positions.Length; i++)
        {
            if (_occupiedPositions.Contains(_positions[i]))
            {
                continue;
            }
            else {
                SpawnTarget(_positions[i]);
                break;
            }
        }
    }

	private void SpawnTarget(Transform pos)
	{
		var target = Instantiate(_target, transform);
		target.transform.position = pos.position;
        _occupiedPositions.Add(pos);
		_targetList.Add(target);
        target.Initialize(this, pos);
	}

	public void RemoveElementFromList(CollisionDetection target, Transform pos) {
        _targetList.Remove(target);
        _occupiedPositions.Remove(pos);
        StartCoroutine(SpawnElementsRoutine(UnityEngine.Random.Range(2.5f, 5.0f)));

	}

   
}
