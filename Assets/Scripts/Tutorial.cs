using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void UnfreezeGame()
    {
        Time.timeScale = 1;
    }
}
