using TMPro;
using UnityEngine;

/* 
This script will run across all scenes. As such, please only include code that will exist for every scene. 
Any code that doesn't should simply reference the GameManager object. (e.g. GameManager.Instance.GetCandy())
*/

public class GameManager : MonoBehaviour
{
    private GameObject AddFeatureButton;
    private GameObject FeatureBar;
    private GameObject SaveButton;
    private GameObject HealthBar;
    private GameObject InventoryButton;
    private GameObject FarmButton;
    private GameObject MapButton;

    private TextMeshProUGUI FeatureBarText;

    private int FeatureCost = 0;
    private int FeatureProgress = 0;

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
        SaveButton = GameObject.FindGameObjectWithTag("SaveButton");
        MapButton = GameObject.FindGameObjectWithTag("MapButton");
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar");
        InventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        FarmButton = GameObject.FindGameObjectWithTag("FarmButton");

        FeatureBarText = AddFeatureButton.GetComponentInChildren<TextMeshProUGUI>();

        AddFeatureButton.SetActive(false);
        FeatureBar.SetActive(false);
        DisableFeatures();

        candy = 28;
        // Calls AddCandy() after 0 seconds, every 1 second
        InvokeRepeating("AddCandy", 0.0f, 1.0f);
    }

    // *********   PUBLIC METHODS     **********
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

    public int GetFeatureCost()
    {
        return FeatureCost;
    }

    public void EnableAddFeatureButton()
    {
        AddFeatureButton.SetActive(true);
    }


    public void EnableNextFeature()
    {
        switch (FeatureProgress)
        {
            case 0:
                if (CanSpend(30))
                {
                    SpendCandy(30);
                    FeatureBar.SetActive(true);
                    DisableFeatures();
                    FeatureBarText.text = "Request another one (5 candies)";
                    SetFeatureCost(5);
                    FeatureProgress++;
                }
            break;
            case 1:
                if (CanSpend(5))
                {
                    SpendCandy(5);
                    SaveButton.SetActive(true);
                    FeatureBarText.text = "Request for something more exciting (5 candies)";
                    FeatureProgress++;
                }
                break;
            case 2:
                if (CanSpend(5))
                {
                    SpendCandy(5);
                    HealthBar.SetActive(true);
                    FeatureBarText.text = "Final request! This one has to be worth the candies. (10 candies)";
                    SetFeatureCost(10);
                    FeatureProgress++;
                }
                break;
            case 3:
                if (CanSpend(10))
                {
                    SpendCandy(10);
                    MapButton.SetActive(true);
                    AddFeatureButton.SetActive(false);
                    FeatureProgress++;
                }
                break;

            default:
                break;
        }
    }


    // *********   PRIVATE METHODS     **********
    private void AddCandy()
    {
        candy += 1;
    }

    private void DisableFeatures()
    {
        SaveButton.SetActive(false);
        MapButton.SetActive(false);
        HealthBar.SetActive(false);
        InventoryButton.SetActive(false);
        FarmButton.SetActive(false);
    }

    private void SetFeatureButtonText(string text)
    {
        FeatureBarText.text = text;
    }

    private void SetFeatureCost(int cost)
    {
        FeatureCost = cost;
    }

}
