using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EatButton;
    public GameObject addFeatureButton;
    public GameObject featureBar;
    
    // Start is called before the first frame update
    void Start()
    {
        // Hide the eat candies button at the start
        EatButton.SetActive(false);
        addFeatureButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Reveal the eat candies button after getting 10 candies
        if (CandyCounter.instance.GetCandy() >= 10)
        {
            EatButton.SetActive(true);
        }
        if (CandyCounter.instance.GetCandy() >= 30)
            addFeatureButton.SetActive(true);
    }
}
