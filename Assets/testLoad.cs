using UnityEngine;

public class testLoad : MonoBehaviour
{
    private GameManager gameManager;
    private FeatureBar featureBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        gameManager = GameManager.Instance;
        featureBar = FeatureBar.Instance;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
