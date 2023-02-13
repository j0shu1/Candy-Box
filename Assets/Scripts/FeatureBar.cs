using System.Collections.Generic;
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

    // Purchase button components.
    private int candyCount;
    private int featureCost;

    /// <summary>
    /// Queue of features to be added.
    /// </summary>
    private Queue<GameObject> FeatureQueue { get; }

    void Start()
    {
        // Begin the game with FeatureBar and AddFeatureButton not active.
        featureBar = GameObject.FindGameObjectWithTag("FeatureBar");
        featureBar.SetActive(false);

        addFeatureButton = GameObject.FindGameObjectWithTag("AddFeatureButton");
        addFeatureButton.SetActive(false);

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
        if (FeatureQueue.Count != 0)
        {
            GameObject nextFeature = FeatureQueue.Dequeue();

            if (nextFeature != healthBar)
                nextFeature.SetActive(true);
            else 
            {
                // If the feature we are enabling is the HealthBar, also delete the AddFeatureButton.
                Destroy(addFeatureButton);
                nextFeature.SetActive(true);
            }
        }
    }

    //public void SpawnFeatureBar(GameObject featureBar = new FeatureBar())
    //{
        //Instantiate(featurebar // Add other parameters);
    //}
}
