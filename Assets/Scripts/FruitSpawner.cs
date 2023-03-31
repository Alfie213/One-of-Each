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
            Debug.Log("Enabled coroutine");
            GameObject randomFruit = _fruits[Random.Range(0, _fruits.Length)];
            Vector3 randomPosition = new Vector3(0, 0, 0);// здесь нужны взять размер экрана и у него взять рандомную точку.
            Instantiate(randomFruit, randomPosition, Quaternion.identity, this.transform);
            yield return new WaitForSeconds(1f); // Здесь какой-то коэф выставить
        }
    }
}
