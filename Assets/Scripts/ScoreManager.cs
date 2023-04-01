using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreData _data;
    [SerializeField] private TextMeshProUGUI _bestScore;

    private void Awake()
    {
        _bestScore.text = $"Best Score: {_data.BestScore}";
    }

    public void UpdateBestScore(int score)
    {
        _data.BestScore = score;
    }
}
