using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySuperCandy : MonoBehaviour
{
    private GameManager gameManager;
    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void BuySCandy(){
        if (gameManager.CanSpend(30)){
            gameManager.SpendCandy(30);
            gameManager.SetMaxHealth();
        }
    }
}
