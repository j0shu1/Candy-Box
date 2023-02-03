using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EatCandies : MonoBehaviour
{
    public int totalCandyEaten;
    public TextMeshProUGUI candyEatenText;
    public GameObject EatButton;

    // Start is called before the first frame update
    void Start()
    {
        EatButton.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.GetCandy() >= 10)
        {
            EatButton.SetActive(true);
        }
    }

    public void EatAllCandies()
    {
        // Can only eat candy if you have at least 1
        if (GameManager.Instance.GetCandy() > 0)
        {
            // Adds current candy total to totalCandyEaten
            totalCandyEaten += GameManager.Instance.GetCandy();
            // Resets candy total
            GameManager.Instance.ResetCandy();
            // Displays the total candy you've eaten
            candyEatenText.text = "You've eaten " + totalCandyEaten + " candies.";
        }
    }

}
