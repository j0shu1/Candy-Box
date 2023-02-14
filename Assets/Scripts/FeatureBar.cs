using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatureBar : MonoBehaviour
{
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

    // Integration vars
    private GameManager gameManager;
    private int featureProgress;

    /// <summary>
    /// Queue of features to be added.
    /// </summary>
    private Queue<GameObject> FeatureQueue { get; }

    void Start()
    {
        gameManager = GameManager.Instance;

        // Begin the game with FeatureBar and AddFeatureButton not active.
        featureBar = GameObject.FindGameObjectWithTag("FeatureBar");
        featureBar.SetActive(false);

        addFeatureButton = GameObject.FindGameObjectWithTag("AddFeatureButton");
        addFeatureButton.SetActive(false);
        addFeatureButtonText = addFeatureButton.GetComponent<TextMeshProUGUI>();

        // Find and save each component of the FeatureBar to the appropriate variable.
        saveButton = GameObject.FindGameObjectWithTag("SaveButton");
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        farmButton = GameObject.FindGameObjectWithTag("FarmButton");
        mapButton = GameObject.FindGameObjectWithTag("MapButton");

        // Add each FeatureBar component to the FeatureQueue.
        FeatureQueue.Enqueue(saveButton);
        FeatureQueue.Enqueue(healthBar);
        FeatureQueue.Enqueue(inventoryButton);
        FeatureQueue.Enqueue(farmButton);
        FeatureQueue.Enqueue(mapButton);
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

    public void SpawnFeatureBar()
    {
        Instantiate(featureBar);
    }

    public void DeleteFeatureBar()
    {
        Destroy(featureBar);
    }

    private void SetFeatureCost(int cost)
    {
        featureCost = cost;
    }

    private void DisableFeatures()
    {
        //TODO implement
    }
}
