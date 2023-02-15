using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public int totalCandyEaten;
    
    // Start is called before the first frame update
    void Start()
    {
        candy = 28;
        // Calls AddCandy() after 0 seconds, every 1 second
        InvokeRepeating("AddCandy", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // PUBLIC METHODS

    public int GetCandy()
    {
        return candy;
    }

    public void ResetCandy()
    {
        candy = 0;
    }

    public void EatCandies()
    {
        totalCandyEaten += GetCandy();
        ResetCandy();
    }

    public int GetTotalCandyEaten()
    {
        return totalCandyEaten;
    }

    public bool CanSpend(int amount)
    {
        return amount <= candy;
    }
    
    public void SpendCandy(int amount)
    {
        candy -= amount;
    }
    
    // PRIVATE METHODS

    private void AddCandy()
    {
        candy += 1;
    }
}
