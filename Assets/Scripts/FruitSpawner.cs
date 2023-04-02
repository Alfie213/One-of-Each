using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _startSpeed;
    [SerializeField] private GameObject[] _fruits;

    [Header("Other")]
    [SerializeField] private GameObject _spawnParent;

    [Header("Limits")]
    [SerializeField] private float _leftPoint;
    [SerializeField] private float _rightPoint;

    private float _currentSpeed;

    private IEnumerator _spawnerRoutine;

    public int CountOfFruits { get; private set; }

    private void Awake()
    {
        if (_startSpeed == 0f) _startSpeed = 2f;
        _currentSpeed = _startSpeed;
        CountOfFruits = 3;

        _spawnerRoutine = Spawner();
    }

    private void Start()
    {
        StartCoroutine(MoreFruits());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            GameObject randomFruit = _fruits[Random.Range(0, CountOfFruits)];
            Instantiate(randomFruit, new Vector3(Random.Range(_leftPoint, _rightPoint), 6, 0), Quaternion.identity, _spawnParent.transform);
            _currentSpeed -= Time.timeScale * 0.05f;
            if (_currentSpeed < 0.5f) _currentSpeed = 0.5f;
            yield return new WaitForSeconds(_currentSpeed);
        }
    }

    private IEnumerator MoreFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            if (!(CountOfFruits == 5))
            {
                CountOfFruits++;
                Debug.Log("Increased");
            }
        }
    }

    public void ClearInstantiatedFruits()
    {
        StopCoroutine(_spawnerRoutine);
        for (int i = 0; i < _spawnParent.transform.childCount; i++)
        {
            Destroy(_spawnParent.transform.GetChild(i).gameObject);
        }
        StartCoroutine(_spawnerRoutine);
    }
}
