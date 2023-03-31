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

    private void Awake()
    {
        if (_startSpeed == 0f) _startSpeed = 1f;
        _currentSpeed = _startSpeed;
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            //Debug.Log("Preparing for spawn");
            GameObject randomFruit = _fruits[Random.Range(0, _fruits.Length)];
            //Debug.Log($"Between {_leftPoint} and {_rightPoint}");
            Instantiate(randomFruit, new Vector3(Random.Range(_leftPoint, _rightPoint), 6, 0), Quaternion.identity, _spawnParent.transform);
            //Instantiate(randomFruit, new Vector3(_leftPoint, 6, 0), Quaternion.identity, _spawnParent.transform);
            //Instantiate(randomFruit, new Vector3(_rightPoint, 6, 0), Quaternion.identity, _spawnParent.transform);

            yield return new WaitForSeconds(1f); // Здесь какой-то коэф выставить
        }
    }
}
