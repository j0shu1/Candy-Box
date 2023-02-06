using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyCounter : MonoBehaviour
{
    public int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public TextMeshProUGUI candyText;

    // Update is called once per frame
    void Update()
    {
        // Changes the text to Candies: <candies>
        candy = GameManager.Instance.GetCandy();
        candyText.text = "Candies: " + candy;
    }
}
