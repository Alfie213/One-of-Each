using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _startHealth;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _template;

    [Header("Cart Components")]
    [SerializeField] private CartMovement _cartMovement;
    [SerializeField] private Collider2D _cartCollider;

    [Header("ScoreManager")]
    [SerializeField] private ScoreManager _scoreManager;

    private int _currentHealth;

    private void Awake()
    {
        if (_startHealth <= 0) _startHealth = 3;
        _currentHealth = _startHealth;

        for (int i = 0; i < _startHealth; i++)
        {
            Instantiate(_heartPrefab, this.transform);
        }
    }

    public void DecreaseHealth()
    {
        _currentHealth -= 1;
        Destroy(transform.GetChild(0).gameObject);
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _cartMovement.enabled = false;
        _cartCollider.enabled = false;
        _template.SetActive(true);
        _scoreManager.UpdateBestScore();
    }
}
