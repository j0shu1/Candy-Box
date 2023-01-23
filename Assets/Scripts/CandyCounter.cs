using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyCounter : MonoBehaviour
{
    public int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public TextMeshProUGUI candyText;
    
    public static CandyCounter instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        candy = 0;
        // Calls AddCandy() after 0 seconds, every 1 second
        InvokeRepeating("AddCandy", 0.0f, 1.0f);
    }

    void AddCandy()
    {
        candy += 1;
    }

    public int GetCandy()
    {
        return candy;
    }
    
    public void ResetCandy()
    {
        candy = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Changes the text to Candies: <candies>
        
        candyText.text = "Candies: " + candy;
    }
}
