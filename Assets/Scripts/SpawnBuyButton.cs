using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnBuyButton : MonoBehaviour
{
    public GameObject buyWeaponPrefab;

    private GameManager gameManager;
    private int purchaseProgress = 0;
    private GameObject buyWeaponButton;
    private TextMeshProUGUI buyWeaponText;
    private static string buyWeaponString = "Buy a wooden sword (150 candies)";


    private void Awake()
    {
        gameManager = GameManager.Instance;
        purchaseProgress = gameManager.GetWeapon();

        CreateBuyWeaponButton();
    }

    private void CreateBuyWeaponButton()
    {
        if (gameManager.GetWeaponBuy() == false)
            return;


        Instantiate(buyWeaponPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        buyWeaponButton = GameObject.FindGameObjectWithTag("BuyWeaponButton");

        buyWeaponText = buyWeaponButton.GetComponentInChildren<TextMeshProUGUI>();
        buyWeaponText.text = buyWeaponString;
    }
}
