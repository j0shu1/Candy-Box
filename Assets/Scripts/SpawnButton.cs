using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject ButtonToSpawn;
    public string ConditionToCheck;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        switch(ConditionToCheck)
        {
            case "NextMap":
                if (gameManager.GetNextMapEnabled())
                    Instantiate(ButtonToSpawn, GameObject.FindGameObjectWithTag("Canvas").transform);
                break;

            case "FinalBoss":
                if (gameManager.GetFinalBossEnabled())
                    Instantiate(ButtonToSpawn, GameObject.FindGameObjectWithTag("Canvas").transform);
                break;

            default: 
                break;
        }
    }
}
