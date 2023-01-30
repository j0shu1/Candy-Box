using UnityEngine;

public class showFeatureBar : MonoBehaviour
{
    private GameObject featureBar;

    private void Start()
    {
        featureBar = GameObject.FindGameObjectWithTag("FeatureBar");
    }

    public void ShowBar()
    {
        featureBar.SetActive(true);
    }
}
