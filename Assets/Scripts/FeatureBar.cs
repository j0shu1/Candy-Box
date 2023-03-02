using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeatureBar : MonoBehaviour
{
    // TODO: Add MakeAddFeatureVisible.cs to this script (if it's possible. It might not be because the FeatureBar object will be disabled.).
    //       It should also instantiate the button from a prefab instead of making it visible.
    // TODO: Make a new private variable to hold the text for the addFeatureButton.
    //       Also make the addFeatureButton a prefab with a script which gets the text and sets it appropriately. 


    // Feature bar components.
    private GameObject featureBar;
    private GameObject addFeatureButton;
    private GameObject saveButton;
    private GameObject healthBar;
    private GameObject inventoryButton;
    private GameObject farmButton;
    private GameObject mapButton;
    private TextMeshProUGUI addFeatureButtonText;

    private Dictionary<GameObject, bool> features = new Dictionary<GameObject, bool>();

    // Purchase button components.
    private int candyCount;
    private int featureCost;

    public GameObject featureBarPrefab;

    // Internal components
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

        features.Add(featureBar, false);
        features.Add(addFeatureButton, false);
        features.Add(saveButton, false);
        features.Add(healthBar, false);
        features.Add(inventoryButton, false);
        features.Add(farmButton, false);
        features.Add(mapButton, false);

        HandleFeatures();
    }


    public void EnableAddFeatureButton()
    {
        features[addFeatureButton] = true;
        HandleFeatures();
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
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Buy);
        switch (featureProgress)
        {
            case 0:
                if (gameManager.CanSpend(30))
                {
                    gameManager.SpendCandy(30);
                    EnableFeature(featureBar);
                    addFeatureButtonText.text = "Request another one (5 candies)";
                    SetFeatureCost(5);
                    featureProgress++;
                }
                break;
            case 1:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    EnableFeature(saveButton);
                    addFeatureButtonText.text = "Request for something more exciting (5 candies)";
                    featureProgress++;
                }
                break;
            case 2:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    EnableFeature(healthBar);
                    addFeatureButtonText.text = "Final request! This one has to be worth the candies. (10 candies)";
                    SetFeatureCost(10);
                    featureProgress++;
                }
                break;
            case 3:
                if (gameManager.CanSpend(10))
                {
                    gameManager.SpendCandy(10);
                    EnableFeature(mapButton);
                    Destroy(addFeatureButton);
                    featureProgress++;
                }
                break;
            case 4:
                EnableFeature(inventoryButton);
                featureProgress++;
                break;
            case 5:
                EnableFeature(farmButton);
                featureProgress++;
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

    private void EnableFeature(GameObject feature)
    {
        if (features.ContainsKey(feature))
        {
            features[feature] = true;
            HandleFeatures();
        }
        else
        {
            Debug.Log("EnableFeature() was called on an object not in features Dictionary!");
        }
    }
    private void HandleFeatures()
    {
        foreach (GameObject current in features.Keys)
        {
            current.SetActive(features[current]);
        }
    }
}
