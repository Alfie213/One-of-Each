using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
