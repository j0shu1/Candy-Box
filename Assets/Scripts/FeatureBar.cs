using TMPro;
using UnityEngine;

public class FeatureBar : MonoBehaviour
{
    // TODO: Add MakeAddFeatureVisible.cs to this script.
    // TODO: Add ShowFeature.cs to this script.
    // Feature bar components.
    private GameObject featureBar;
    private GameObject addFeatureButton;
    private GameObject saveButton;
    private GameObject healthBar;
    private GameObject inventoryButton;
    private GameObject farmButton;
    private GameObject mapButton;
    private TextMeshProUGUI addFeatureButtonText;

    // Purchase button components.
    private int candyCount;
    private int featureCost;

    private GameManager gameManager;
    private int featureProgress;

    void Start()
    {
        gameManager = GameManager.Instance;

        featureBar = GameObject.FindGameObjectWithTag("FeatureBar");
        addFeatureButton = GameObject.FindGameObjectWithTag("AddFeatureButton");
        addFeatureButtonText = addFeatureButton.GetComponentInChildren<TextMeshProUGUI>();

        // Find and save each component of the FeatureBar to the appropriate variable.
        saveButton = GameObject.FindGameObjectWithTag("SaveButton");
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        farmButton = GameObject.FindGameObjectWithTag("FarmButton");
        mapButton = GameObject.FindGameObjectWithTag("MapButton");

        featureBar.SetActive(false);
        addFeatureButton.SetActive(false);
        DisableFeatures();
    }

    public void SpawnFeatureBar()
    {
        Instantiate(featureBar);
    }

    public void DeleteFeatureBar()
    {
        Destroy(featureBar);
    }

    public void EnableAddFeatureButton()
    { 
        addFeatureButton.SetActive(true);
    }
    public int GetFeatureCost()
    {
        return featureCost;
    }

    /// <summary>
    /// Adds the next feature to the FeatureBar.
    /// </summary>
    public void EnableNextFeature()
    {
        switch (featureProgress)
        {
            case 0:
                if (gameManager.CanSpend(30))
                {
                    gameManager.SpendCandy(30);
                    featureBar.SetActive(true);
                    DisableFeatures();
                    addFeatureButtonText.text = "Request another one (5 candies)";
                    SetFeatureCost(5);
                    featureProgress++;
                }
                break;
            case 1:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    saveButton.SetActive(true);
                    addFeatureButtonText.text = "Request for something more exciting (5 candies)";
                    featureProgress++;
                }
                break;
            case 2:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    healthBar.SetActive(true);
                    addFeatureButtonText.text = "Final request! This one has to be worth the candies. (10 candies)";
                    SetFeatureCost(10);
                    featureProgress++;
                }
                break;
            case 3:
                if (gameManager.CanSpend(10))
                {
                    gameManager.SpendCandy(10);
                    mapButton.SetActive(true);
                    Destroy(addFeatureButton);
                    featureProgress++;
                }
                break;
            default:
                break;
        }
    }

    // PRIVATE METHODS
    private void SetFeatureCost(int cost)
    {
        featureCost = cost;
    }

    private void DisableFeatures()
    {
        saveButton.SetActive(false);
        mapButton.SetActive(false);
        healthBar.SetActive(false);
        inventoryButton.SetActive(false);
        farmButton.SetActive(false);
    }
}
