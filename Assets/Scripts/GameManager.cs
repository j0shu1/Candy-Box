using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EatButton;
    
    // Start is called before the first frame update
    void Start()
    {
        // Hide the eat candies button at the start
        EatButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Reveal the eat candies button after getting 10 candies
        if (CandyCounter.instance.GetCandy() >= 10)
        {
            EatButton.SetActive(true);
        }
    }
}
