using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _template;

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
        _template.SetActive(true);
    }
}
