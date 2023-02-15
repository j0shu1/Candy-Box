using TMPro;
using UnityEngine;

public class ShowFeature : MonoBehaviour
{
    private int candyCount;
    private GameManager gameManager;

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
        gameManager.EnableNextFeature();
    }
}
