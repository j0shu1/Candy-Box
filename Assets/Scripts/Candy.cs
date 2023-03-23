using UnityEngine;

public class Candy : MonoBehaviour
{
    public int startingCandy;
    public int candy; // Int overflow throws an error because it is checked. See AddCandies() and AddCandy().
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

    public void AddCandies(int amount)
    {
        if (amount > 0)
            checked { candy += amount; }
        else
            Debug.LogError("Tried to add negative or zero candies to candies.");
    }
    
    // PRIVATE METHODS

    private void AddCandy()
    {
        checked { candy += 1; }
    }
}
