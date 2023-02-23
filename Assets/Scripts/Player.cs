using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject healthBar;
    public Slider healthSlider;
    private GameManager gameManager;
    
    private int attack = 10; // Just a default value
    private int weaponSelection = 0; //default weapon selected
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        InvokeRepeating("Regen", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameManager.Instance;
        healthSlider.value = currentHealth;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        int WeaponIndex = gameManager.GetWeapon();
        switch(WeaponIndex)
        {
            case 0: SetAttack(1); break;
            case 1: SetAttack(10); break;
            case 2: SetAttack(20); break;
            case 3: SetAttack(30); break;
        }
    }


    // COMBAT FUNCTIONS
    public void SetAttack(int number)
    {
        attack = number;
    }
    
    public int GetAttack()
    {
        return attack;
    }

    void Regen()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // WEAPON SELECTION
    public void SetWeapon(int number)
    {
        weaponSelection = number;
    }
    public int GetWeapon()
    {
        return weaponSelection;
    }
}
