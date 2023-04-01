using System;
using TMPro;
using UnityEngine;

public class FruitChanger : MonoBehaviour
{
    [Header("Fruits")]
    [SerializeField] private Sprite[] _allFruits;
    [SerializeField] private SpriteRenderer[] _currentFruits;
    [SerializeField] private SpriteRenderer[] _spots;
    [SerializeField] private FruitSpawner _fruitSpawner;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI _score;

    private bool[] _collected;
    public bool[] Collected => _collected;
    [HideInInspector] public SpriteRenderer[] CurrentFruits => _currentFruits;

    private void Awake()
    {
        _collected = new bool[_currentFruits.Length];
        UpdateFruits();
    }

    public void CollectFruit(Sprite collectedFruit, out bool added)
    {
        added = false;
        bool collectedAll = true;
        for (int i = 0; i < _currentFruits.Length; i++)
        {
            if (_currentFruits[i].sprite == collectedFruit && !_collected[i])
            {
                _currentFruits[i].color = new Color(_currentFruits[i].color.r, _currentFruits[i].color.g, _currentFruits[i].color.b, 1);
                _spots[i].sprite = collectedFruit;
                _collected[i] = true;
                added = true;
                foreach (var item in _collected)
                {
                    if (!item) collectedAll = false;
                }
                if (collectedAll)
                {
                    //Debug.Log("Collected all");
                    CollectedAll();
                }
                break;
            }
        }
    }

    private void CollectedAll()
    {
        foreach (var item in _spots)
        {
            item.sprite = null;
        }
        _score.text = (Convert.ToInt32(_score.text) + 1).ToString();
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
            _currentFruits[i].color = new Color(_currentFruits[i].color.r, _currentFruits[i].color.g, _currentFruits[i].color.b, 0.4f);
            _currentFruits[i].sprite = _allFruits[UnityEngine.Random.Range(0, _fruitSpawner.CountOfFruits)];
        }
    }
}
