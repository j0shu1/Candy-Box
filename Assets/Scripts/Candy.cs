using UnityEngine;

public class Candy : MonoBehaviour
{
    public int startingCandy;
    private int candy; // Might want to make this long in case of integer overflow, but int should suffice
    private int totalCandyEaten;
    
    // Start is called before the first frame update
    void Start()
    {
        candy = startingCandy;
        // Calls AddCandy() after 0 seconds, every 1 second
        InvokeRepeating("AddCandy", 0.0f, 1.0f);
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
