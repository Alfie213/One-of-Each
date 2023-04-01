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
        if (_startSpeed == 0f) _startSpeed = 2f;
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
            GameObject randomFruit = _fruits[Random.Range(0, _fruits.Length)];
            Instantiate(randomFruit, new Vector3(Random.Range(_leftPoint, _rightPoint), 6, 0), Quaternion.identity, _spawnParent.transform);
            _currentSpeed -= Time.timeScale * 0.05f;
            if (_currentSpeed < 0.3f) _currentSpeed = 0.3f;
            yield return new WaitForSeconds(_currentSpeed);
        }
    }
}
