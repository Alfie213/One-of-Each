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
            bool destroy = false;
            _fruitChanger.CollectFruit(collision.gameObject.GetComponent<SpriteRenderer>().sprite, out destroy);
            if (destroy)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
