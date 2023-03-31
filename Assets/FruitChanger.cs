using System;
using TMPro;
using UnityEngine;

public class FruitChanger : MonoBehaviour
{
    [Header("Fruits")]
    [SerializeField] private Sprite[] _allFruits;
    [SerializeField] private SpriteRenderer[] _currentFruits;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI _score;

    private bool[] _collected;

    private void Awake()
    {
        _collected = new bool[_currentFruits.Length];
    }

    public void CollectFruit(Sprite collectedFruit)
    {
        bool collectedAll = true;
        for (int i = 0; i < _currentFruits.Length; i++)
        {
            if (_currentFruits[i].sprite == collectedFruit && !_collected[i])
            {
                _currentFruits[i].color = new Color(_currentFruits[i].color.r, _currentFruits[i].color.g, _currentFruits[i].color.b, 255);
                _collected[i] = true;
                foreach (var item in _collected)
                {
                    if (!item) collectedAll = false;
                }
                if (collectedAll)
                {
                    Debug.Log("Collected all");
                    CollectedAll();
                }
                break;
            }
        }
    }

    private void CollectedAll()
    {
        // Добавить очки
        _score.text = (Convert.ToInt32(_score.text) + 1).ToString();
        // Сгенерить новые
        UpdateFruits();
    }

    private void UpdateFruits()
    {
        for (int i = 0; i < _collected.Length; i++)
        {
            _collected[i] = false;
        }
        for (int i = 0; i < _currentFruits.Length; i++)
        {
            _currentFruits[i].color = new Color(_currentFruits[i].color.r, _currentFruits[i].color.g, _currentFruits[i].color.b, 0.1f);
            _currentFruits[i].sprite = _allFruits[UnityEngine.Random.Range(0, _allFruits.Length)];
        }
        //foreach (var fruit in _currentFruits)
        //{
        //    fruit.color = new Color(fruit.color.r, fruit.color.g, fruit.color.b, 100);
        //    fruit.sprite = _allFruits[UnityEngine.Random.Range(0, _allFruits.Length)];
        //}
        //_firstFruit.sprite = _allFruits[Random.Range(0, _allFruits.Length)];
        //_secondFruit.sprite = _allFruits[Random.Range(0, _allFruits.Length)];
        //_thirdFruit.sprite = _allFruits[Random.Range(0, _allFruits.Length)];
    }
}
