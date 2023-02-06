using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyPouch : MonoBehaviour
{
    public TextMeshProUGUI candyText;
    void Start(){
        candyText.text = "Candies: " + CandyCounter.instance.GetCandy();
    }
    void Update()
    {
        // Changes the text to Candies: <candies>
        candyText.text = "Candies: " + CandyCounter.instance.GetCandy();
    }
}
