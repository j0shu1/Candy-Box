using TMPro;
using UnityEngine;

public class ShowFeature : MonoBehaviour
{
    private int candyCount;
    private GameManager gameManager;
    private string GenericMessage = "Request a new feature from the developer ";

    public TextMeshProUGUI AddFeatureText;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void Update()
    {
        candyCount = gameManager.GetCandy();
    }
    public void ApplyFeature()
    {
        if (gameManager.SpendCandy(30)) // If this amount can be spent
        { 
            AddFeatureText.text = GenericMessage + "(cost: TEST candies)";
            gameManager.SpendCandy(30);
            gameManager.EnableFeatureBar();
        }
    }
}
