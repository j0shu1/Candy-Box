using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EatCandies : MonoBehaviour
{
    public int candyEaten;
    public TextMeshProUGUI candyEatenText;
    public GameObject EatButton;

    // Start is called before the first frame update
    void Start()
    {
        EatButton.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.GetCandy() >= 10 || GameManager.Instance.EatCandyScript == true)
        {
            GameManager.Instance.EatCandyScript = true;
            EatButton.SetActive(true);
            if (GameManager.Instance.GetTotalCandyEaten() > 0)
            {
                // Displays the total candy you've eaten
                candyEatenText.text = "You've eaten " + GameManager.Instance.GetTotalCandyEaten() + " candies.";
            }
        }
    }

    public void EatAllCandies()
    {
        // Can only eat candy if you have at least 1
        if (GameManager.Instance.GetCandy() > 0)
        {
            GameManager.Instance.EatCandies();
        }
    }

}
