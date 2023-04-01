using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreData _data;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _currentScore;

    private void Awake()
    {
        _bestScore.text = $"Best Score: {_data.BestScore}";
    }

    public void UpdateBestScore()
    {
        _data.BestScore = Convert.ToInt32(_currentScore.text);
    }
}
