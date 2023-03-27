using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySuperCandy : MonoBehaviour
{
    private GameManager gameManager;
    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        gameObject.GetComponent<Button>().interactable = gameManager.GetCandy() >= 30;
    }

    public void BuySCandy(){
        if (gameManager.CanSpend(30))
        {
            gameManager.SpendCandy(30);
            gameManager.SetMaxHealth();
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Eat);
        }
    }
}
