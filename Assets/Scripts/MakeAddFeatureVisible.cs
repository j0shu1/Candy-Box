using UnityEngine;
using UnityEngine.UI;

public class MakeAddFeatureVisible : MonoBehaviour
{
    public Button AddFeatureButton;
    private GameManager gameManager;
    private int candyCount;
    private int featureCost;
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (AddFeatureButton != null)
        {
            candyCount = gameManager.GetCandy();
            featureCost = gameManager.GetFeatureCost();

            if (candyCount >= 30)
                gameManager.EnableAddFeatureButton();

            if (candyCount >= featureCost)
                AddFeatureButton.interactable = true;
            else
                AddFeatureButton.interactable = false;
        }

    }
}
