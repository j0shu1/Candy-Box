using System.Diagnostics;
using UnityEngine;
using UnityEngine.Assertions;

/* 
This script will run across all scenes. As such, please only include code that will exist for every scene. 
Any code that doesn't should simply reference the GameManager object. (e.g. GameManager.Instance.GetCandy())
*/

public class GameManager : MonoBehaviour
{
    private GameObject AddFeatureButton;
    private GameObject FeatureBar;
    public static GameManager Instance;
    
    private int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public int totalCandyEaten;

    public bool EatCandyScript; // Unsure if this is the best way to keep the EatCandy button visible despite scene changes

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        AddFeatureButton = GameObject.FindGameObjectWithTag("AddFeatureButton");
        FeatureBar = GameObject.FindGameObjectWithTag("FeatureBar");
        AddFeatureButton.SetActive(false);
        FeatureBar.SetActive(false);
        candy = 28;
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

    public void EatCandies()
    {
        totalCandyEaten += GetCandy();
        ResetCandy();
    }
    
    public int GetTotalCandyEaten()
    {
        return totalCandyEaten;
    }

    public bool SpendCandy(int amount)
    {
        if (candy - amount > 0)
        {
            candy -= amount;
            return true;
        }
        else { return false; }
    }

    public void EnableFeatureBar()
    {
        FeatureBar.SetActive(true);
    }
    public void EnableAddFeatureButton()
    {
        AddFeatureButton.SetActive(true);
    }

}