using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBuyButton : MonoBehaviour
{
    public GameObject buyWeaponPrefab;

    private GameManager gameManager;
    private GameObject buyWeaponButton;
    private Button buyWeaponButtonButton;
    private TextMeshProUGUI buyWeaponText;
    private static int weaponTier = 0;
    private static int buyWeaponCost = 150;
    private static string buyWeaponString = "Buy a wooden sword (150 candies)";

    void Awake()
    {
        gameManager = GameManager.Instance;

        CreateBuyWeaponButton();
    }

    private void Update()
    {
        if (buyWeaponButton != null) 
            buyWeaponButtonButton.interactable = gameManager.GetCandy() >= buyWeaponCost;
    }

    private void CreateBuyWeaponButton()
    {
        if (gameManager.GetWeaponBuy() == false)
            return;


        Instantiate(buyWeaponPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        buyWeaponButton = GameObject.FindGameObjectWithTag("BuyWeaponButton");

        buyWeaponText = buyWeaponButton.GetComponentInChildren<TextMeshProUGUI>();
        buyWeaponButtonButton = buyWeaponButton.GetComponent<Button>();
        
        buyWeaponText.text = buyWeaponString;
    }

    public void BuyWeapon()
    {
        switch (weaponTier)
        {
            case 0:
                if (gameManager.CanSpend(150))
                {
                    gameManager.SpendCandy(150);
                    gameManager.SetWeapon(1);
                    gameManager.EnableNextFeature();

                    buyWeaponString = "Buy an iron axe (400 candies)";
                    buyWeaponCost = 400;
                    buyWeaponText.text = buyWeaponString;
                    weaponTier++;
                }
                break;
            case 1:
                if (gameManager.CanSpend(400))
                {
                    gameManager.SpendCandy(400);
                    gameManager.SetWeapon(2);

                    buyWeaponString = "Buy a polished silver sword (2 000 candies)";
                    buyWeaponCost = 2000;
                    buyWeaponText.text = buyWeaponString;
                    weaponTier++;
                }
                break;
            case 2:
                if (gameManager.CanSpend(2000))
                {
                    gameManager.SpendCandy(2000);
                    gameManager.SetWeapon(3);
                    gameManager.SetWeaponBuy(false);

                    Destroy(buyWeaponButton);
                    weaponTier++;
                }
                break;

            default:
                break;
        }
    }
}
