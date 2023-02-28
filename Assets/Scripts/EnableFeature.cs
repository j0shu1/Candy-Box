using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFeature : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void EnableNewFeature()
    {
        gameManager = GameManager.Instance;
        gameManager.EnableNextFeature();

    }
}
