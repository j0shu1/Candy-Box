using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyPouch : MonoBehaviour
{
    public TextMeshProUGUI candyText;
    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
        candyText.text = "Candies: " + gameManager.candy.GetCandy();
    }
    void Update()
    {
        // Changes the text to Candies: <candies>
        candyText.text = "Candies: " + gameManager.candy.GetCandy();
    }
}
