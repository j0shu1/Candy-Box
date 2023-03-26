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
    private static int buyWeaponCost = 100;
    private static string buyWeaponString = "Buy a wooden sword (100 candies)";

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
                if (gameManager.CanSpend(100))
                {
                    gameManager.SpendCandy(100);
                    gameManager.SetWeapon(1);
                    //gameManager.EnableNextFeature();

                    buyWeaponString = "Buy an iron axe (200 candies)";
                    buyWeaponCost = 200;
                    buyWeaponText.text = buyWeaponString;
                    weaponTier++;
                }
                break;
            case 1:
                if (gameManager.CanSpend(200))
                {
                    gameManager.SpendCandy(200);
                    gameManager.SetWeapon(2);

                    buyWeaponString = "Buy a polished silver sword (450 candies)";
                    buyWeaponCost = 450;
                    buyWeaponText.text = buyWeaponString;
                    weaponTier++;
                }
                break;
            case 2:
                if (gameManager.CanSpend(450))
                {
                    gameManager.SpendCandy(450);
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
