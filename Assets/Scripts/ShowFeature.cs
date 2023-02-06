using TMPro;
using UnityEngine;

public class ShowFeature : MonoBehaviour
{
    private int Progress;
    private int candyCount;
    private GameManager gameManager;
    private string GenericMessage = "Request a new feature from the developer ";

    public TextMeshProUGUI AddFeatureText;
    public GameObject featureBar;
    public GameObject saveButton;
    public GameObject healthBar;
    public GameObject mapButton;
    public GameObject addFeatureButton;
    public GameObject inventoryButton;
    public GameObject lollipopFarmButton;

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
        switch (Progress)
        {
            case 0:
                AddFeatureText.text = GenericMessage + "(cost: TEST candies)";
                gameManager.SpendCandy(30);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                gameManager.EnableFeatureBar();
=======
                featureBar.SetActive(true);
>>>>>>> parent of 24332f9 (healthbar)
=======
                featureBar.SetActive(true);
>>>>>>> parent of 24332f9 (healthbar)
=======
                featureBar.SetActive(true);
>>>>>>> parent of 24332f9 (healthbar)
                healthBar.SetActive(false);
                mapButton.SetActive(false);
                addFeatureButton.SetActive(false);
                inventoryButton.SetActive(false);
                lollipopFarmButton.SetActive(false);
                break;
            case 1:
                saveButton.SetActive(true);
                break;
            case 2:
                healthBar.SetActive(true);
                break;
            case 3:
                mapButton.SetActive(true);
                addFeatureButton.SetActive(false);
                break;
            case 4:
                inventoryButton.SetActive(true);
                break;
            case 5:
                lollipopFarmButton.SetActive(true);
                break;
            default:
                break;
        }
        Progress++;
    }
}
