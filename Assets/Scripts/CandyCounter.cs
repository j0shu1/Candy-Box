using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyCounter : MonoBehaviour
{
    public int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public TextMeshProUGUI candyText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Changes the text to Candies: <candies>
        candy = gameManager.candy.GetCandy();
        candyText.text = "Candies: " + candy;
    }
}
