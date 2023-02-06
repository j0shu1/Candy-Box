using UnityEngine;

/* 
This script will run across all scenes. As such, please only include code that will exist for every scene. 
Any code that doesn't should simply reference the GameManager object. (e.g. GameManager.Instance.GetCandy())
*/

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject addFeatureButton;
    public GameObject featureBar;
    
    public int candy; // Might want to make this long in case of integer overflow, but int should suffice
    public int totalCandyEaten;

    public bool EatCandyScript; // Unsure if this is the best way to keep the EatCandy button visible despite scene changes

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        addFeatureButton.SetActive(false);

        candy = 0;
        // Calls AddCandy() after 0 seconds, every 1 second
        InvokeRepeating("AddCandy", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetCandy() >= 30)
            addFeatureButton.SetActive(true);
    }

    void AddCandy()
    {
        candy += 1;
    }

    public int GetCandy()
    {
        return candy;
    }
    
    public void ResetCandy()
    {
        candy = 0;
    }

    public void EatCandies()
    {
        totalCandyEaten += GetCandy();
        ResetCandy();
    }
    
    public int GetTotalCandyEaten()
    {
        return totalCandyEaten;
    }
}
