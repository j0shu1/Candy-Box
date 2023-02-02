using UnityEngine;

public class ShowFeature : MonoBehaviour
{
    private int _progress;
    public GameObject featureBar;
    public GameObject saveButton;
    public GameObject healthBar;
    public GameObject mapButton;
    public GameObject addFeatureButton;
    public GameObject inventoryButton;
    public GameObject lollipopFarmButton;

    public void Start()
    {
        featureBar.SetActive(false);
    }
    public void ApplyFeature()
    {
        switch (_progress)
        {
            case 0:
                featureBar.SetActive(true);
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
        _progress++;
    }
}
