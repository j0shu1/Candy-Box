using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EatCandies : MonoBehaviour
{
    public int totalCandyEaten;
    public TextMeshProUGUI candyEatenText;
    // Start is called before the first frame update
    public void EatAllCandies()
    {
        // Can only eat candy if you have at least 1
        if (CandyCounter.instance.GetCandy() > 0)
        {
            // Adds current candy total to totalCandyEaten
            totalCandyEaten += CandyCounter.instance.GetCandy();
            // Resets candy total
            CandyCounter.instance.ResetCandy();
            // Displays the total candy you've eaten
            candyEatenText.text = "You've eaten " + totalCandyEaten + " candies.";
        }
    }

}
