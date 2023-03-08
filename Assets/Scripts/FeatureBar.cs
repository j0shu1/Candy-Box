using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class FeatureBar : MonoBehaviour
{
    // TODO: Add MakeAddFeatureVisible.cs to this script (if it's possible. It might not be because the FeatureBar object will be disabled.).
    //       It should also instantiate the button from a prefab instead of making it visible.
    // TODO: Make a new private variable to hold the text for the addFeatureButton.
    //       Also make the addFeatureButton a prefab with a script which gets the text and sets it appropriately. 
    public GameObject addFeatureButtonPrefab;

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
    private int featureCost = 30;
    private int candyCount;
    private static string addFeatureString = "Request a new feature from the developer (30 candies)";
    private Button addButton;

    public GameObject featureBarPrefab;

    // Internal components
    private GameManager gameManager;
    private static int featureProgress = 0;

    void Start()
    {
        gameManager = GameManager.Instance;

        featureBar = GameObject.FindGameObjectWithTag("FeatureBar");

        // Find and save each component of the FeatureBar to the appropriate variable.
        saveButton = GameObject.FindGameObjectWithTag("SaveButton");
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
        farmButton = GameObject.FindGameObjectWithTag("FarmButton");
        mapButton = GameObject.FindGameObjectWithTag("MapButton");

        features.Add(featureBar, false);
        features.Add(saveButton, false);
        features.Add(healthBar, false);
        features.Add(inventoryButton, false);
        features.Add(farmButton, false);
        features.Add(mapButton, false);

        HandleFeatures();
    }

    private void Awake()
    {
        CreateAddFeatureButton();
        HandleFeatures();
    }



    public void DebugAddAllFeatures()
    {
        for (int i = featureProgress; i < features.Count; i++)
        {
            EnableNextFeature();
        }
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

    public string GetAddFeatureString() { return addFeatureString; }

    /// <summary>
    /// Adds the next feature to the FeatureBar.
    /// </summary>
    public void EnableNextFeature()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Buy);
        // Debug.Log("Executing enable feature with progress of " + featureProgress);
        switch (featureProgress)
        {
            case 0:
                if (gameManager.CanSpend(30))
                {
                    gameManager.SpendCandy(30);
                    EnableFeature(featureBar);
                    SetAddFeatureText("Request another one (5 candies)");
                    SetFeatureCost(5);
                    featureProgress++;
                }
                break;
            case 1:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    EnableFeature(saveButton);
                    SetAddFeatureText("Request for something more exciting (5 candies)");
                    featureProgress++;
                }
                break;
            case 2:
                if (gameManager.CanSpend(5))
                {
                    gameManager.SpendCandy(5);
                    EnableFeature(healthBar);
                    SetAddFeatureText("Final request! This one has to be worth the candies. (10 candies)");
                    SetFeatureCost(10);
                    featureProgress++;
                }
                break;
            case 3:
                if (gameManager.CanSpend(10))
                {
                    gameManager.SpendCandy(10);
                    EnableFeature(mapButton);
                    features.Remove(addFeatureButton);
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

    private void SetAddFeatureText(string entry)
    {
        addFeatureButtonText.text = entry;
        addFeatureString = entry;
    }

    private void CreateAddFeatureButton()
    {
        if (featureProgress > 3)
            return;

        addFeatureButton = Instantiate(addFeatureButtonPrefab,
                                       GameObject.FindGameObjectWithTag("Canvas").transform);
        if (features.ContainsKey(addFeatureButton))
            features[addFeatureButton] = true;
        else
            features.Add(addFeatureButton, true);

        addFeatureButtonText = addFeatureButton.GetComponentInChildren<TextMeshProUGUI>();
        addFeatureButtonText.text = addFeatureString;
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
            Debug.LogError("EnableFeature() was called on an object not in features Dictionary!");
        }
    }
    private void HandleFeatures()
    {
        foreach (GameObject current in features.Keys)
        {
            try
            {
                current.SetActive(features[current]);
            }
            catch
            { 
                addFeatureButton = GameObject.FindGameObjectWithTag("FeatureBar");
            }
        }
    }
}
