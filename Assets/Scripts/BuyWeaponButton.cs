using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponButton : MonoBehaviour
{
    private SpawnBuyButton buttonSpawner;
    void Start()
    {
        buttonSpawner = GameObject.FindGameObjectWithTag("ButtonSpawner").GetComponent<SpawnBuyButton>();
    }

    public void BuyWeapon() { buttonSpawner.BuyWeapon(); }
}
