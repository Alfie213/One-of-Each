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
    private int _leftEdge, _rightEdge;
    [SerializeField] private GameObject _leftBarrier;
    [SerializeField] private GameObject _rightBarrier;

    private float _currentSpeed;

    private void Awake()
    {
        if (_startSpeed == 0f) _startSpeed = 1f;
        _currentSpeed = _startSpeed;

        _leftEdge = (int)_leftBarrier.GetComponent<RectTransform>().rect.width + (int)_fruits[0].GetComponent<RectTransform>().rect.width * 4;
        _rightEdge = Screen.width - (int)_rightBarrier.GetComponent<RectTransform>().rect.width - (int)_fruits[0].GetComponent<RectTransform>().rect.width * 4;
        Debug.Log(_leftEdge);
        Debug.Log(_rightEdge);
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            Debug.Log("Preparing for spawn");
            GameObject randomFruit = _fruits[Random.Range(0, _fruits.Length)];
            Debug.Log($"Between {_leftEdge} and {_rightEdge}");
            Instantiate(randomFruit, new Vector3(Random.Range(_leftEdge, _rightEdge), Screen.height, 0), Quaternion.identity, _spawnParent.transform);
            yield return new WaitForSeconds(1f); // Здесь какой-то коэф выставить
        }
    }
}
