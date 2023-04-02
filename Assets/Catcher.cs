using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private FruitChanger _fruitChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            for (int i = 0; i < _fruitChanger.CurrentFruits.Length; i++)
            {
                if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == _fruitChanger.CurrentFruits[i].sprite && !_fruitChanger.Collected[i])
                {
                    _health.DecreaseHealth();
                    Destroy(collision.gameObject);
                    return;
                }
            }
        }
    }
}
