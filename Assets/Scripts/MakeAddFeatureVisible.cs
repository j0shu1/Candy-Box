using UnityEngine;

public class MakeAddFeatureVisible : MonoBehaviour
{
    public GameObject AddFeatureButton;
    public GameObject FeatureBar;
    private int candyCount;
    void Start()
    {
        FeatureBar.SetActive(false);
        AddFeatureButton.SetActive(false);
    }

    void Update()
    {
        candyCount = GameManager.Instance.GetCandy();

        if (candyCount >= 30)
            AddFeatureButton.SetActive(true);
    }
}
