using UnityEngine;

public class AddFeatureScript : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void EnableNextFeature() { gameManager.EnableNextFeature(); }
}