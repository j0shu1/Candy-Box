using UnityEngine;

public class MakeAddFeatureVisible : MonoBehaviour
{
    public GameObject AddFeatureButton;
    private GameManager gameManager;
    private int candyCount;
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        candyCount = GameManager.Instance.GetCandy();

        if (candyCount >= 30)
            gameManager.EnableAddFeatureButton();
    }
}
