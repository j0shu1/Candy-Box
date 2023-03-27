using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Give1Mil : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    
    public void GiveMil()
    {
        
        GameManager.Instance.AddCandies(1000000);
        SceneManager.LoadScene(12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
