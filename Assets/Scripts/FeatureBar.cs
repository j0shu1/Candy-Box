using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureBar : MonoBehaviour
{
    private GameObject featureBar;
    private GameObject saveButton;
    private GameObject healthBar;
    private GameObject inventoryButton;
    private GameObject farmButton;
    private GameObject mapButton;

    private Queue<GameObject> components;

    void Start()
    {
        components.Enqueue(saveButton);
        components.Enqueue(healthBar);
        components.Enqueue(inventoryButton);
        components.Enqueue(farmButton);
        components.Enqueue(mapButton);
    }

    public FeatureBar()
    {

    }

    public void EnableNextFeature()
    {
        if (components.Count != 0)
        {
            GameObject nextFeature = components.Dequeue();
            nextFeature.SetActive(true);
        }
    }

    public GameObject GetFeatureBar()
    {
        return featureBar;
    }

    //public void SpawnFeatureBar(GameObject featureBar = new FeatureBar())
    //{
        //Instantiate(featurebar // Add other parameters);
    //}
}
