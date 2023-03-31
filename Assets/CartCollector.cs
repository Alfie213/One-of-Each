using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollector : MonoBehaviour
{
    [SerializeField] private FruitChanger _fruitChanger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            _fruitChanger.CollectFruit(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }
}
